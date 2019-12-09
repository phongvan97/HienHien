# Tổ chức thư mục trong project:
<ul>
 <li>App_Data : Chưa dùng đến</li>
 <li>App_Start : Chưa RouteConfig</li>
 <li>Assets : Chứa Css, Js, Icon dùng cho theme</li>
 <li>Controllers: Chứa các controllers theo từng nhóm người dùng</li>
 <ul>
  <li>AdmiControllers: Dành cho addmins</li>
  <li>StaffControllers: Dành cho nhân viên</li>
  <li>DoctorController: Dành cho bác sĩ</li>
  <li>PatientCotrollers: Dành cho bệnh nhân</li>
  <li>Login_outControllers: Đăng nhập / Đăng xuất</li>
 </ul>
 <li>Models:</li>
 <ul>
  <li>BussinessModels: Xử lí nghiệp vụ úng với từng bảng trong DataBase</li>
  <li>EntityModels: Tham chiếu đến Database, sử dụng EntityFrameWork</li>
  <li>DBContexts: Lớp DatabaseContext sử dụng kết nối trong EntityFrameWork</li>
 </ul>
 <li>Views:</li>
 <ul>
  <li>
   .... Chưa viết
  </li>
 </ul>
</ul>
