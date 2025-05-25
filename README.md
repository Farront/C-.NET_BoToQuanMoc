# C-.NET_BoToQuanMoc
Chương trình quản lý nhà hàng sử dụng C#.NET
Thay địa chỉ đường dẫn cơ sở dữ liệu trong SqlConnection connect bằng vị trí của cơ sở dữ liệu, trong tất cả các file trong Class, Form và User Control
Đường dẫn ban đâu: SqlConnection connect = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\Documents\BTQM.mdf;Integrated Security=True;Connect Timeout=30");

Cần thay đổi địa chỉ phần: @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Lenovo\Documents\BTQM.mdf -> @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= DiaChiCoSoDuLieu

Username: admin
Password: 123

Trân trọng
