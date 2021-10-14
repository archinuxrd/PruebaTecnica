namespace Tec.Web.Models.Error
{
    public class ErrorViewModel
    {
        #region Properties
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
        #endregion
    }
}
