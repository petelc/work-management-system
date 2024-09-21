namespace WMS.Shared;

public class UnitTest1
{
    [Fact]
    public void DatabaseConnectTest()
    {
        using (WmsContext db = new())
        {
            Assert.True(db.Database.CanConnect());
        }
    }

    [Fact]
    public void CategoryCountTest()
    {
        using (WmsContext db = new())
        {
            int expected = 8;
            int actual = db.Categories.Count();
            Assert.Equal(expected, actual);
        }
    }
}