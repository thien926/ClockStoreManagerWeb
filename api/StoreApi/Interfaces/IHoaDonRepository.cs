namespace StoreApi.Interfaces
{
    public interface IHoaDonRepository
    {
        HoaDon HoaDon_Add(HoaDon hd); 
        HoaDon HoaDon_GetById(int id); 
        IEnumerable<HoaDon> HoaDon_GetAll();
        HoaDon HoaDon_Update(HoaDon hd); 
        void HoaDon_Delete(HoaDon hd); 
        IEnumerable<HoaDon> HoaDon_FilterAdmin(string search, string sort, int pageIndex, int pageSize, out int count);
    }
}