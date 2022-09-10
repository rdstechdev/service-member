using Member.Context;
using Member.Helper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace Member.Services
{
    public class MemberService
    {
        private MemberContext db = new MemberContext();
        public SearchList<Memberlist> Search(List<Filter> param)
        {
            List<Memberlist> list = new List<Memberlist>();
            PageData pageData = new PageData();
            if (param.Any())
            {
                FilterConstructor _filter = new FilterConstructor(param);
                list = db.Memberlists.Where(_filter.Construct(),_filter.Expressions()).ToList();
                pageData.Currentpage = 1;
                pageData.Totalpage = (int)Math.Ceiling((decimal)list.Count/10);
                pageData.Totaldata = list.Count;
                pageData.Pagesize = 10;
                list = list.Skip(0).Take(10).ToList();
            }

            return new SearchList<Memberlist>(list, pageData);
        }
    }
}
