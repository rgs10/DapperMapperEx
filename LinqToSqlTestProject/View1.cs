using System.Data.Linq;
using System.Linq;
using System.Windows.Forms;

namespace LinqToSqlTestProject
{
    public partial class View1 : Form
    {
        public View1()
        {
            InitializeComponent();
            var dataClasses1DataContext = new DataClasses1DataContext();
            IMultipleResults multipleResults = dataClasses1DataContext.pCustomPublicHolidaysMultipleResult();

            var dayList = multipleResults.GetResult<AnnualHoliday>().ToList();

            var annualHolidayList = multipleResults.GetResult<Day>().ToList();
        }
    }
}
