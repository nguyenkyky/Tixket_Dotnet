using Microsoft.AspNetCore.SignalR;




public class DatVeHub : Hub
{
    private static List<UserGheDat> returnDanhSachGheDangDat = new List<UserGheDat>();
    public async Task datGhe(string taiKhoan, string danhSachGheDangDat)
    {
        returnDanhSachGheDangDat.RemoveAll(ghe => ghe.TaiKhoan == taiKhoan);
        var gheDat = new UserGheDat { TaiKhoan = taiKhoan, DanhSachGheDangDat = danhSachGheDangDat };
        returnDanhSachGheDangDat.Add(gheDat);
        await Clients.All.SendAsync("dsGheDangDat", returnDanhSachGheDangDat);
    }

    public async Task huyDat(string taiKhoan)
    {
        // Tìm và xóa (nếu có) danh sách ghế đang đặt của tài khoản được truyền vào
        returnDanhSachGheDangDat.RemoveAll(ghe => ghe.TaiKhoan == taiKhoan);

        // Gửi danh sách ghế đang đặt cập nhật cho tất cả clients
        await Clients.All.SendAsync("dsGheDangDat", returnDanhSachGheDangDat);
    }

    public async Task layDanhSachGheDangDat()
    {
        await Clients.All.SendAsync("dsGheDangDat", returnDanhSachGheDangDat);
    }


    public async Task datVeThanhCong(string taiKhoan)
    {
        // Tìm và xóa (nếu có) danh sách ghế đang đặt của tài khoản được truyền vào
        returnDanhSachGheDangDat.RemoveAll(ghe => ghe.TaiKhoan == taiKhoan);

        // Gửi danh sách ghế đang đặt cập nhật cho tất cả clients
        await Clients.All.SendAsync("dsGheDangDat", returnDanhSachGheDangDat);
        await Clients.All.SendAsync("datVeThanhCong");

    }


}


public class UserGheDat
{
    public string TaiKhoan { get; set; }
    public string DanhSachGheDangDat { get; set; }
}