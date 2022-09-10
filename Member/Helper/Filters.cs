using Member.Context;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Member.Helper
{
    public class Filter
    {
        public string Field { get; set; }
        public string Operator { get; set; }
        public string Keyword { get; set; }
        
    }
    public class FilterConstructor
    {
        public List<Filter> _filters { get; set; }
        public FilterConstructor(List<Filter> filters)
        {
            _filters = filters;
        }
        public string Construct()
        {
            List<string> _clauseList = new List<string>();
            for (int i = 0; i < _filters.Count; i++)
            {
                _clauseList.Add("@"+i+"(it)");
            }
            return string.Join(" AND ", _clauseList);
        }
        public Expression Expressions()
        {
            string _ex = "";
            List<string> _clauseList = new List<string>();

            foreach (var item in _filters)
            {
                if(item.Operator.ToLower() == "like")
                {
                    _clauseList.Add("x."+item.Field+ ".Contains(\""+item.Keyword.ToLower()+"\")");
                }
                else
                {
                    _clauseList.Add("x." + item.Field + " " + item.Operator + " " + item.Keyword);
                }
            }
            _ex = string.Join(" AND ", _clauseList);
            Expression _expression = DynamicExpressionParser.ParseLambda<Memberlist, bool>(new ParsingConfig(), true, "x => "+_ex);
            
            return _expression;

        }
    }
}
