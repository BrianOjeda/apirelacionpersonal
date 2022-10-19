namespace ApiRelacionPersonas.Api
{
    public class PaginationDto
    {
        public int Page { get; set; } = 1;
        public int RecordsPerPage { get => _recordsPerPage; 
                                 set =>_recordsPerPage = (value>_maximumPerPage)?_maximumPerPage:value;
                               }


        private int _recordsPerPage = 10;
        private readonly int _maximumPerPage = 50;

    }
}
