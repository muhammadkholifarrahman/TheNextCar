 THE NEXT CAR APPS
The Next Car adalah sebuah project MVC yang dibuat dengan tujuan pada keamanan saat mengendarai mobil.

# Scope of Functionalities
- Apa kegunaan DoorController.cs?

- Apa kegunaan Model Door.cs?

- Apa kegunaan Interface OnDoorChanged ?

- Apa kegunaan DoorController.cs ?

# Kegunaan DoorController.cs ?
Door.cs berguna untuk mengetahui fungsi door Closed atau Locked.

```csharp
class DoorController
    {
        private Door door;
        private OnDoorChanged onDoorChanged;

        public DoorController(OnDoorChanged onDoorChanged)
        {
            this.onDoorChanged = onDoorChanged;
            this.door = new Door();
        }
        public void close()
        {
            this.door.close();
            this.onDoorChanged.doorStatusChanged("CLOSED", "door is closed");
        }
        public void open()
        {
            this.door.open();
            this.onDoorChanged.doorStatusChanged("OPENED", "door is opened");
        }
        public void activateLock()
        {
            if (this.door.isClosed())
            {
                this.door.activateLock();
                onDoorChanged.doorSecurityChanged("LOCKED", "door is locked");
            }
            else
            {
                unlock();
            }
        }
        public void unlock()
        {
            this.door.unlock();
            onDoorChanged.doorSecurityChanged("UNLOCKED", "door is unlocked");
        }
        public bool isClose()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked();
        }

    
```

# Kegunaan Door.cs ?
Door.cs berguna untuk mengetahui fungsi door Closed atau Locked.

```csharp
class Door
    {
        private bool locked;
        private bool closed;

        public void close()
        {
            this.closed = true;
        }
        public void open()
        {
            this.closed = false;
        }
        public void activateLock()
        {
            this.locked = true;
        }
        public void unlock()
        {
            this.locked = false;
        }
        public bool isLocked()
        {
            return this.locked;
        }
        public bool isClosed()
        {
            return this.closed;
        }
    }
```

# Kegunaan OnDoorChanged ?
OnDoorChanged berfungsi untuk mengganti fungsi dari Door dan DoorController.

```csharp
public DoorController(OnDoorChanged callbackOnDoorchanged)
        {
            this.callbackOnDoorchanged = callbackOnDoorchanged;
            this.door = new Door();
        }
        public void close()
        {
            this.door.close();
            this.callbackOnDoorchanged.OnDoorOpenStateChanged("CLOSED", "door closed");
        }
        public void open()
        {
            this.door.open();
            this.callbackOnDoorchanged.OnDoorOpenStateChanged("OPENED", "door opened");
        }
        public void activateLock()
        {
            this.door.activateLock();
            this.callbackOnDoorchanged.OnDoorOpenStateChanged("LOCKED", "door locked");
        }
        public void unlock()
        {
            this.door.unlock();
            this.callbackOnDoorchanged.OnDoorOpenStateChanged("UNLOCKED", "ddoor unlocked");
        }
        public bool isClose()
        {
            return this.door.isClosed();
        }
        public bool isLocked()
        {
            return this.door.isLocked();
        }
    }
    interface OnDoorChanged
    {
        void OnLockDoorStateChanged(string value, string message);

        void OnDoorOpenStateChanged(string value, string message);
    }
}
```
