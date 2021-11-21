namespace StoreApi.Interfaces
{
    public interface KieuDayRepository
    {
        KieuDay KieuDay_Add(KieuDay sp); 
        KieuDay KieuDay_GetById(int id); 
        IEnumerable<KieuDay> KieuDay_GetAll();
        KieuDay KieuDay_Update(KieuDay NV); 
        void KieuDay_Delete(KieuDay NV); 
        IEnumerable<KieuDay> KieuDay_FilterAdmin(string search, string sort, int pageIndex, int pageSize, out int count);
    }
}