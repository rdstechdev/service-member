﻿namespace Member.Helper
{
    public class SearchList<T>
    {
        public List<T> Listdata { get; set; }

        public bool Success { get; set; }

        public PageData Pagedata { get; set; }

        public ErrorMessage Errormessage { get; set; }

        public SearchList()
        {
        }

        public SearchList(List<T> list)
        {
            Listdata = list;
            Success = true;
        }

        public SearchList(List<T> list, PageData pagedata)
        {
            Listdata = list;
            Pagedata = pagedata;
            Success = true;
        }
    }

    public class PageData
    {
        public int Currentpage { get; set; }
        public int Pagesize { get; set; }
        public int Totalpage { get; set; }
        public int Totaldata { get; set; }

        public PageData()
        {

        }

        public PageData(int currentpage, int pagesize, int totalpage, int totaldata)
        {
            Currentpage = currentpage;
            Pagesize = pagesize;
            Totalpage = totalpage;
            Totaldata = totaldata;
        }
    }

    public class ErrorMessage
    {
        public string errorcode { get; set; }
        public string errordescription { get; set; }
    }
}
