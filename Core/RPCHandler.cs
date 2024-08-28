// ----------------------------------------------------------------------------
//    W T D E       L A U N C H E R       V 3
//       R P C       H A N D L E R
//
//    Main logic class for handling Discord Rich Presence (RPC). This class is
//    abstract and cannot be created.
// ----------------------------------------------------------------------------
// V3 launcher imports.
// We don't need any for now...

// Required imports.
using System;
using DiscordRPC;

namespace WTDE_Launcher_V3.Core {
    /// <summary>
    ///  Main logic class for handling Discord Rich Presence (RPC). This class is abstract and cannot be created.
    /// </summary>
    abstract public class RPCHandler {
        /// <summary>
        ///  The RPC client used for Discord rich presence.
        /// </summary>
        public static DiscordRpcClient RPCClient;

        // - - - - - - - - - - - - - - - - - - - - - - - - - -

        /// <summary>
        ///  Initializes the RPC client.
        /// </summary>
        public static void InitializeRPC() {
            try {
                RPCClient = new DiscordRpcClient("1278492826870616114", autoEvents: false);
                RPCClient.Initialize();

                //~ V3LauncherCore.AddDebugEntry($"Connected with application ID {RPCClient.ApplicationID}", "Discord RPC");

            } catch (Exception exc) {
                V3LauncherCore.AddDebugEntry($"Error connecting to Discord: {exc.Message}", "Discord RPC");
            }
        }

        /// <summary>
        ///  Shut down the RPC client. The RPC client gets marked as <see cref="null"/>.
        /// </summary>
        public static void ShutdownRPC() {
            RPCClient.Dispose();
            RPCClient = null;
        }

        /// <summary>
        ///  Update the status of the RPC client.
        /// </summary>
        public static void UpdateRPCStatus(RichPresence richPres) {
            RPCClient.SetPresence(richPres);
            RPCClient.Invoke();
        }

        /// <summary>
        ///  Makes an RPC status object from basic C# type data. This is meant to be a more comprehensive way of
        ///  making a new <see cref="RichPresence"/> object that can the main RPC client can update to.
        /// </summary>
        /// <param name="details">
        ///  Text describing what the user is currently doing.
        /// </param>
        /// <param name="state">
        ///  Party status, if needed.
        /// </param>
        /// <param name="largeImageKey">
        ///  Name of the large image. This can be a URL or path, I think.
        /// </param>
        /// <param name="largeImageText">
        ///  Text shown when the mouse is hovered over the large image in the Rich Presence status.
        /// </param>
        /// <param name="smallImageKey">
        ///  Name of the small image. This can be a URL or path, I think.
        /// </param>
        /// <param name="smallImageText">
        ///  Text shown when the mouse is hovered over the small image in the Rich Presence status.
        /// </param>
        /// <returns>
        ///  A new <see cref="RichPresence"/> object with all of the basic data provided in.
        /// </returns>
        public static RichPresence MakeRPCStatusFromBasicData(string details, string state, string largeImageKey, string largeImageText, string smallImageKey, string smallImageText) {
            var finalPresence = new RichPresence() {
                Details = details,
                State = state,
                Assets = new Assets() {
                    LargeImageKey = largeImageKey,
                    LargeImageText = largeImageText,
                    SmallImageKey = smallImageKey,
                    SmallImageText = smallImageText
                }
            };
            return finalPresence;
        }

        /// <summary>
        ///  Sets the details text on the active RPC status.
        /// </summary>
        /// <param name="text">
        ///  Text to display.
        /// </param>
        public static void SetRPCDetails(string text) {
            RPCClient.UpdateDetails(text);
        }

        /// <summary>
        ///  Sets the state text on the active RPC status.
        /// </summary>
        /// <param name="text">
        ///  Text to display.
        /// </param>
        public static void SetRPCState(string text) {
            RPCClient.UpdateState(text);
        }

        /// <summary>
        ///  Set the large image and its hover text on the active RPC status.
        /// </summary>
        /// <param name="url">
        ///  URL to the image to display.
        /// </param>
        /// <param name="hoverText">
        ///  Text to display when hovered over.
        /// </param>
        public static void SetRPCLargeImage(string url, string hoverText = "") {
            RPCClient.UpdateLargeAsset(url, hoverText);
        }

        /// <summary>
        ///  Set the small image and its hover text on the active RPC status.
        /// </summary>
        /// <param name="url">
        ///  URL to the image to display.
        /// </param>
        /// <param name="hoverText">
        ///  Text to display when hovered over.
        /// </param>
        public static void SetRPCSmallImage(string url, string hoverText = "") {
            RPCClient.UpdateSmallAsset(url, hoverText);
        }
    }
}
