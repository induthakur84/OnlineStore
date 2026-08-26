namespace ProjectCommonCode
{
    public class PageResults<T>
    {

        //PAgenumber=1
        // PageSize=10
        // totalnumberofRecords=100,
        //Results


        // this current Page

        public int PageNumber{get;set;}


        // Page Size


        public int PageSize { get;set;}

        public int TotalNumberOfRecords {get;set;}  


        public IEnumerable<T> Results {get;set;}

    }
}
