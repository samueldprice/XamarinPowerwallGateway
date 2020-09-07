
namespace App1.Models
{
    public interface IPowerwallMapper
    {
        PowerwallStatus Map(Aggregates aggregates, Soe soe);
    }
}