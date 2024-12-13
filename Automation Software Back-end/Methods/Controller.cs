[ApiController] /* Enhances Controller.cs, allowing for automatic behavioral changes */
[Route("api/[controller]")] /* Sets API routing to be whatever [controller] is */

public class POSTrequest : ControllerBase { /* Instances ControllerBase for API function inheritance */

    private readonly DataService _dataService; /* Private dataService variable injected via dependency injection from DepInj.cs */

    public POSTrequest(DataService dataService) { /* Constructor instancing the DataService class in regard to dependency injection */
        _dataService = dataService; /* Converting private temp data into global usable data */
    }

    [HttpPost] /* Sets request type to be POST */
    [Route("fi-data")] /* Sets route ending to be "fi-data", referencing FetchRequest.tsx */

    public IActionResult Receiver([FromBody] object JSONdata) { /* Flexible response handler which binds fi-data to object parameter, allowing for dynamic POST request */
        if (JSONdata == null) {
            return BadRequest(new {CallLog = "Error! Data not found. Please retry."});
        }
        else {
            _dataService.SaveData(JSONdata); /* Finalizes storage process, saves data and ready for access */
            return Ok(new {CallLog = "Success! Data has been accessed and is now ready for use!"});
        }
    }
}
