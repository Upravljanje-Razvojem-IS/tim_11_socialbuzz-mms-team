using System.Collections.Generic;

namespace UserContentService.Entities
{
    public class PASMock
    {
        public int Id { get; set; }
        public string Description { get; set; }


    }

    public static class PASMockConstants
    {
        public static List<PASMock> pASMocks = new List<PASMock>()
        {
            new PASMock()
            {
                Id = 1,
                Description = "Product"
            },
            new PASMock() { Id = 2, Description = "Service"},
            new PASMock() { Id = 3, Description = "Prodcut 2"},
            new PASMock() { Id = 4, Description = "Service 2"}
        };
    }
}
