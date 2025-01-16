using InTechCommon.Constants;
using System.Runtime.CompilerServices;

namespace InTechCommon.Exceptions
{
    public static class InTechErrorHandler 
    {
        public static InTechException HandleError(Exception ex, string? message = null, object? parameters = null, [CallerFilePath]string path= "", [CallerMemberName]string method = "" ) 
        {
            InTechException? nex = new InTechException();
            try
            {
                if (ex.GetType() == typeof(InTechException))
                { 
                     nex = (InTechException)ex;
                }
                else
                {  
                    nex.CustomMessage = message ?? ex.Message;
                    nex.StatusCode = HttpStatusCodes.INTERNAL_SERVER_ERROR;                    
                }

                if (!nex.IsHandled)
                {
                    string s = nex.Message;
                }
            }
            catch (Exception exc)
            {
                string s = exc.Message;
            }

            return nex;
        }

        public static void LogError(Exception ex, string Location)
        {
            //To log error in different destinations like file or db
            //try
            //{
                
            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }
    }
}
