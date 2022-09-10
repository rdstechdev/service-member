using Member.Helper;
using Member.Context;

namespace Member.Services
{
    public interface IMemberService
    {
        public SearchList<Memberlist> Search(Filter param);

        //public Form<ProductDto> Add(ProductDto productDto);
    }
}
