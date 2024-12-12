[ApiController] /* Enhances Controller.cs, allowing for automatic behavioral changes */
[Route("api/[controller]")] /* Sets API routing to be whatever [controller] is */

public class POSTrequest : ControllerBase { /* Instances ControllerBase for API function inheritance */
    [HttpPost] /* Sets request type to be POST */
    [Route("fi-data")] /* Sets route ending to be "fi-data", referencing FetchRequest.tsx */

    public IActionResult Receiver([FromBody] object JSONdata) { /* Flexible response handler which binds fi-data to object parameter, allowing for dynamic POST request */
        if (JSONdata == null) {
            return BadRequest(new {CallLog = "Error! Data not found. Please retry."});
        }
        else {
            return Ok(new {CallLog = "Success! Data has been accessed and is now ready for use!"});
        }
    }
}
