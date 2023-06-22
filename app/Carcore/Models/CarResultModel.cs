using Carcode.Models;

namespace Carcore.Models
{
    public class CarResultModel
    {
        public int Count { get; set; }
        public string Message { get; set; }
        public string SearchCriteria { get; set; }
        public List<CarModel> Results { get; set; }
    }
}