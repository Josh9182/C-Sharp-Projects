public class ServiceData { /* Dependency Injection for Controller.cs, responsible for data storage and retrieval */
    private object _dataStorage; /* Private variable for encapsulation, unable to modify unless internal */

    public void SaveData(object data) { /* Method for converting private temp data into global permanent data */
        _dataStorage = data;
    }

    public object ReturnData() { /* Method for returning stored data, finalizing Dependency Injection */
            return _dataStorage;
    }
}
