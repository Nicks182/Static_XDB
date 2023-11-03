using PhotinoNET;
using Services;
using SharpHTML;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace Static_XDB
{
    internal class Program
    {
        const string G_IconFile = "wwwroot/favicon.ico";
        static PhotinoWindow G_PhotinoWindow = null;
        static Srv_MessageBus G_Srv_MessageBus = null;
        static Srv_Logic G_Srv_Logic = null;

        [STAThread]
        static void Main(string[] args)
        {
            G_Srv_MessageBus = new Srv_MessageBus();
            G_Srv_MessageBus.RegisterEvent(Srv_MessageBus_EventNames.TransportMessage, (P_Message) =>
            {
                G_PhotinoWindow.SendWebMessage(P_Message.ToString());
            });

            G_Srv_Logic = new Srv_Logic(G_Srv_MessageBus);

            // Window title declared here for visibility
            string windowTitle = "Static-XDB";

            string browserControlInitParams = string.Empty;

            if (PhotinoWindow.IsWindowsPlatform)
            {
                // Windows specific initialization parameters
                browserControlInitParams = "--enable-smooth-scrolling";
            }

            // Creating a new PhotinoWindow instance with the fluent API
            G_PhotinoWindow = new PhotinoWindow()
                .SetTitle(windowTitle)
                .SetBrowserControlInitParameters(browserControlInitParams)
                //.SetIconFile("wwwroot/favicon.ico")
                // Resize to a percentage of the main monitor work area
                .SetUseOsDefaultSize(false)
                .SetSize(new Size(1200, 800))
                // Center window in the middle of the screen
                .Center()
                // Users can resize windows by default.
                // Let's make this one fixed instead.
                .SetResizable(true)
                //.RegisterCustomSchemeHandler("app", (object sender, string scheme, string url, out string contentType) =>
                //{
                //    contentType = "text/javascript";
                //    return new MemoryStream(Encoding.UTF8.GetBytes(@"
                //        (() =>{
                //            window.setTimeout(() => {
                //                alert(`🎉 Dynamically inserted JavaScript.`);
                //            }, 1000);
                //        })();
                //    "));
                //})
                // Most event handlers can be registered after the
                // PhotinoWindow was instantiated by calling a registration 
                // method like the following RegisterWebMessageReceivedHandler.
                // This could be added in the PhotinoWindowOptions if preferred.
                .RegisterWebMessageReceivedHandler((object P_Sender, string P_Message) =>
                {
                    var window = (PhotinoWindow)P_Sender;

                    TM_Message L_TM_Message = null;
                    if (string.IsNullOrEmpty(P_Message) == true || P_Message == "init")
                    {
                        L_TM_Message = new TM_Message
                        {
                            Message_Type = TM_Message_Type.Init
                        };
                    }
                    else
                    {
                        L_TM_Message = Newtonsoft.Json.JsonConvert.DeserializeObject<TM_Message>(P_Message);
                    }
                    G_Srv_Logic._ProcessMessage(L_TM_Message);

                    // Send a message back the to JavaScript event handler.
                    // "window.external.receiveMessage(callback: Function)"
                    window.SendWebMessage(SharpHTML.SH_ActionGen._ToJSON_String(L_TM_Message));
                })
                .Load("wwwroot/index.html"); // Can be used with relative path strings or "new URI()" instance to load a website.

            if (File.Exists(G_IconFile) == true)
            {
                G_PhotinoWindow.SetIconFile(G_IconFile);
            }

            G_PhotinoWindow.WaitForClose(); // Starts the application event loop
        }
    }

    

}
