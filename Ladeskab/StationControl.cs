using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladeskab.Interfaces;

namespace Ladeskab
{
    public class StationControl
    {
        // Enum med tilstande ("states") svarende til tilstandsdiagrammet for klassen
        private enum LadeskabState
        {
            Available,
            Locked,
            DoorOpen
        };

        // Her mangler flere member variable
        private LadeskabState _state;
        private IChargeControl _charger;
        private int _oldId;
        private IDoor _door;

        // tilføjet
        private IDisplay _display;
        private IRfidReader _rfidReader;
        private ILogFile _logFile;

        private string logFile = "logfile.txt"; // Navnet på systemets log-fil

        // Her mangler constructor
        // Constructor
        public StationControl(IDoor door, IChargeControl charger, IRfidReader rfidReader, IDisplay display, ILogFile logFile)
        {
            _door = door;
            _charger = charger;
            _rfidReader = rfidReader;
            _display = display;
            _logFile = logFile;
            _state = LadeskabState.Available;
            _door.DoorEvent+= HandleDoorEvent;
            _rfidReader.RfidReaderEvent+= HandleEventRfid;
        }
    

        // Eksempel på event handler for eventet "RFID Detected" fra tilstandsdiagrammet for klassen
        private void RfidDetected(int id)
        {
            switch (_state)
            {
                case LadeskabState.Available:
                    // Check for ladeforbindelse
                    if (_charger.Connected())
                    {
                        _door.LockDoor();
                        _charger.StartCharge();
                        _oldId = id;
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst med RFID: {0}", id);
                        }

                        Console.WriteLine("Skabet er låst og din telefon lades. Brug dit RFID tag til at låse op.");
                        _state = LadeskabState.Locked;
                    }
                    else
                    {
                        Console.WriteLine("Din telefon er ikke ordentlig tilsluttet. Prøv igen.");
                    }

                    break;

                case LadeskabState.Locked:
                    // Check for correct ID
                    if (id == _oldId)
                    {
                        _charger.StopCharge();
                        _door.UnlockDoor();
                        using (var writer = File.AppendText(logFile))
                        {
                            writer.WriteLine(DateTime.Now + ": Skab låst op med RFID: {0}", id);
                        }

                        Console.WriteLine("Tag din telefon ud af skabet og luk døren");
                        _state = LadeskabState.Available;
                    }
                    else
                    {
                        Console.WriteLine("Forkert RFID tag");
                    }

                    break;
            }
        }

        private void HandleDoorEvent(object sender, DoorEventArgs de)
        {
            if (de.IsOpen == true)
            {
                _state = LadeskabState.DoorOpen;
                _display.ConnectPhone();
            }
            if (de.IsOpen == false)
            {
                _state = LadeskabState.Available;
                _display.ReadRfid();
            }
        }

        private void HandleEventRfid (object sender, RfidEventArgs ea)
        {
            RfidDetected(ea.IdTag);
        }

        
    }
}
