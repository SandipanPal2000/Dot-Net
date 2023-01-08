using System.Text.Json.Serialization;

namespace ClassroomManagement.web.Infrstructure.Roles
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum AppRoles
    {
        Teacher = 1,
        Student = 2
    }
}
