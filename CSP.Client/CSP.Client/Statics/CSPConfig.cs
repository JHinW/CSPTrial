using System;
using System.Collections.Generic;
using System.Text;

namespace CSP.Client.Statics
{
    /// <summary>
    /// Partner Center operated by 21Vianet	
    /// https://login.chinacloudapi.cn	
    /// https://graph.chinacloudapi.cn	
    /// https://partner.partnercenterapi.microsoftonline.cn
    /// https://login.chinacloudapi.cn/a3267ba8-bb7b-49ed-9343-760eebbfb58c/wsfed
    /// </summary>
    public class CSPConfig
    {
        public static string PartnerServiceApiRoot = "https://partner.partnercenterapi.microsoftonline.cn";
        public static string Authority = "https://login.chinacloudapi.cn";
        public static string ResourceUrl = "https://graph.chinacloudapi.cn";
        public static string ApplicationId = "b091199c-ced2-495a-b982-291dd455a191";
        public static string ApplicationSecret = "";
        public static string ApplicationDomain = "a3267ba8-bb7b-49ed-9343-760eebbfb58c";
    }
}
