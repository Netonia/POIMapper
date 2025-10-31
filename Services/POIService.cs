using POIMapper.Models;

namespace POIMapper.Services;

public class POIService
{
    private readonly StorageService _storageService;
    private const string StorageKey = "poimapper_pois";
    private List<POI> _pois = new();

    public event Action? OnChange;

    public POIService(StorageService storageService)
    {
        _storageService = storageService;
    }

    public async Task InitializeAsync()
    {
        _pois = await _storageService.GetItemAsync<List<POI>>(StorageKey) ?? new List<POI>();
        NotifyStateChanged();
    }

    public List<POI> GetAll() => _pois;

    public POI? GetById(string id) => _pois.FirstOrDefault(p => p.Id == id);

    public async Task AddAsync(POI poi)
    {
        _pois.Add(poi);
        await SaveAsync();
    }

    public async Task UpdateAsync(POI poi)
    {
        var index = _pois.FindIndex(p => p.Id == poi.Id);
        if (index >= 0)
        {
            _pois[index] = poi;
            await SaveAsync();
        }
    }

    public async Task DeleteAsync(string id)
    {
        _pois.RemoveAll(p => p.Id == id);
        await SaveAsync();
    }

    public List<POI> FilterByCategory(string category)
    {
        if (string.IsNullOrEmpty(category) || category == "All")
            return _pois;
        return _pois.Where(p => p.Category == category).ToList();
    }

    public List<POI> SearchByText(string searchText)
    {
        if (string.IsNullOrEmpty(searchText))
            return _pois;
        
        searchText = searchText.ToLower();
        return _pois.Where(p => 
            p.Name.ToLower().Contains(searchText) || 
            p.Description.ToLower().Contains(searchText)).ToList();
    }

    private async Task SaveAsync()
    {
        await _storageService.SetItemAsync(StorageKey, _pois);
        NotifyStateChanged();
    }

    private void NotifyStateChanged() => OnChange?.Invoke();
}
