using System.Text.Json;

using Windows.Storage;

namespace Repaybl.Helpers
{
    static class LocalSettingHelper
    {
        private static readonly ApplicationDataContainer LocalSettings = ApplicationData.Current.LocalSettings;

        public static void MarkContainer<T>(string key, T value)
        {
            //#if !NETFX_CORE
            var json = JsonSerializer.Serialize(value);
            LocalSettings.Values[key] = json;
            //#else
            //                _ = LocalSettings.CreateContainer(container.ToString(), ApplicationDataCreateDisposition.Always);
            //                LocalSettings.Containers[container.ToString()].Values[containerValue] = value != null ? JsonConvert.SerializeObject(value) : null;
            //#endif

        }

        public static T GetContainerValue<T>(string key)
        {
            //#if !NETFX_CORE
            var json = (string)ApplicationData.Current.LocalSettings.Values[key];
            return JsonSerializer.Deserialize<T>(json);
            //#else

            ////  _ = LocalSettings.CreateContainer(container.ToString(), ApplicationDataCreateDisposition.Always);
            //  if (!(LocalSettings.Containers[container.ToString()].Values[containerValue] is string currentValue))
            //  {
            //      return default;
            //  }
            //  return JsonConvert.DeserializeObject<T>(currentValue);
            //#endif
        }
    }
}
