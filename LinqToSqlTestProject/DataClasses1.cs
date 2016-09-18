using System;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Reflection;

namespace LinqToSqlTestProject
{
    /// <summary>
    /// http://stackoverflow.com/questions/6102605/how-do-i-use-linq-to-sql-with-stored-procedures-returning-multiple-result-sets-w
    /// http://kishor-naik-dotnet.blogspot.co.uk/2011/12/linq-multiple-result-set-of-procedure.html
    ///  </summary>
    partial class DataClasses1DataContext
    {

        [global::System.Data.Linq.Mapping.FunctionAttribute(Name = "dbo.pCustomPublicHolidays")]
        [ResultType(typeof(AnnualHoliday))]
        [ResultType(typeof(Day))]
        public IMultipleResults pCustomPublicHolidaysMultipleResult()
        {
            try
            {
                IExecuteResult result = this.ExecuteMethodCall(this, ((MethodInfo)(MethodInfo.GetCurrentMethod())));
                return ((IMultipleResults)(result.ReturnValue));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }
    }
}