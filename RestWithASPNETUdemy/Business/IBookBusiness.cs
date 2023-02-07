using RestWithASPNETUdemy.Data.VO;
using System.Collections.Generic;

namespace RestWithASPNETUdemy.Business
{
    public interface IBookBusiness
    {
        BookVO Create(BookVO book);
        BookVO FindById(long id);
        BookVO Update(BookVO book);
        List<BookVO> FindAll();
        void Delete(long id);
    }
}
