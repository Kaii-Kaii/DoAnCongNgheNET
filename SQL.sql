create database QL_CH_Xe

use QL_CH_XE

CREATE TABLE NHACUNGCAP(
    MA_NCC CHAR(6) PRIMARY KEY,  -- Mã nhà cung cấp (độ dài tối đa 6 ký tự)
    TEN_NCC NVARCHAR(100) NOT NULL   -- Tên nhà cung cấp (độ dài tối đa 100 ký tự)
);
INSERT INTO NHACUNGCAP(MA_NCC , TEN_NCC) 
VALUES 
('NCC001',N'Honda Việt Nam'),
('NCC002',N'Yamaha Motor Việt Nam'),
('NCC003',N'Suzuki Việt Nam'),
('NCC004',N'Piaggio Việt Nam'),
('NCC005',N'SYM Việt Nam');

select * from NHACUNGCAP

CREATE TABLE LOAISANPHAM (
    MA_LOAI CHAR(7) PRIMARY KEY,  -- Mã loại sản phẩm (độ dài tối đa 10 ký tự)
    TENLOAI NVARCHAR(100) NOT NULL     -- Tên loại sản phẩm (độ dài tối đa 100 ký tự)
);
INSERT INTO LOAISANPHAM (MA_LOAI, TENLOAI) 
VALUES 
('LOAI001',N'Xe tay ga'),
('LOAI002',N'Xe số'),
('LOAI003',N'Xe côn tay');

CREATE TABLE SANPHAM (
    MA_SP CHAR(6) PRIMARY KEY,  -- Mã sản phẩm (độ dài tối đa 6 ký tự)
    TEN_SP NVARCHAR(100) NOT NULL, -- Tên sản phẩm
    MOTA_SP NVARCHAR(255),  -- Mô tả sản phẩm
    SOLUONG_SP INT NOT NULL,  -- Số lượng sản phẩm
    GIA_BAN DECIMAL(18,2) NOT NULL,  -- Giá bán
	GIA_NHAP DECIMAL(18,2) NOT NULL,  -- Giá nhập
    TGBAOHANH INT NOT NULL,  -- Thời gian bảo hành (tháng)
	ANH_SP NVARCHAR(200),
    MA_LOAI CHAR(7) NOT NULL,  -- Mã loại sản phẩm
);
INSERT INTO SANPHAM (MA_SP, TEN_SP, MOTA_SP, SOLUONG_SP, GIA_BAN, GIA_NHAP, TGBAOHANH,ANH_SP, MA_LOAI)
VALUES
('SP001', N'Vision 2024', N'Xe tay ga Honda',		 50, 35000000, 30000000, 24,'image1.png', 'LOAI001'),
('SP002', N'Air Blade 2024', N'Xe tay ga Honda',	 40, 45000000, 40000000, 24,'image2.png', 'LOAI001'),
('SP003', N'Exciter 150', N'Xe côn tay Yamaha',		 30, 50000000, 47000000, 24,'image3.png', 'LOAI003'),
('SP004', N'Sirius 2024', N'Xe số Yamaha',			 60, 25000000, 22000000, 18,'image4.png', 'LOAI002'),
('SP005', N'Janus 2024', N'Xe tay ga Yamaha',		 40, 32000000, 29000000, 24,'image5.png', 'LOAI001'),
('SP006', N'Piaggio Liberty', N'Xe tay ga Piaggio',	 20, 60000000, 55000000, 24,'image6.png', 'LOAI001'),
('SP007', N'Piaggio Vespa', N'Xe tay ga Piaggio',	 15, 80000000, 75000000, 24,'image7.png', 'LOAI001'),
('SP008', N'SYM Galaxy', N'Xe số SYM',				 50, 20000000, 18000000, 18,'image8.png', 'LOAI002'),
('SP009', N'SYM Elegant', N'Xe số SYM',				 60, 18000000, 16000000, 18,'image9.png', 'LOAI002'),
('SP010', N'Suzuki Raider', N'Xe côn tay Suzuki',	 25, 51000000, 47000000, 24,'image10.png','LOAI003');

CREATE TABLE KHACHHANG (
    SDT_KH CHAR(10) PRIMARY KEY,  -- Số điện thoại khách hàng
    TENKH NVARCHAR(100) NOT NULL,  -- Tên khách hàng
    DIACHI_KH NVARCHAR(255),  -- Địa chỉ khách hàng
    MAIL NVARCHAR(100)  -- Email khách hàng
);
INSERT INTO KHACHHANG (SDT_KH, TENKH, DIACHI_KH, MAIL)
VALUES
('0901234567', N'Nguyễn Văn A',		 N'123 Phố Huế, Hà Nội',		 'vana@gmail.com'),
('0912345678', N'Trần Thị B',		 N'456 Lê Lợi, TP.HCM',			 'thib@gmail.com'),
('0923456789', N'Lê Văn C',			 N'789 Trần Hưng Đạo, Đà Nẵng',	 'vanc@gmail.com'),
('0934567890', N'Phạm Văn D',		 N'321 Lý Thái Tổ, Hải Phòng',	 'vand@gmail.com'),
('0945678901', N'Ngô Thị E',		 N'654 Nguyễn Huệ, Nha Trang',	 'thie@gmail.com');

CREATE TABLE NHANVIEN (
    MA_NV CHAR(6) PRIMARY KEY,  -- Mã nhân viên (độ dài tối đa 6 ký tự)
    TENNV NVARCHAR(100) NOT NULL,  -- Tên nhân viên
	GIOITINH NVARCHAR(3) NOT NULL,  -- Giới tính nhân viên
    CHUCVU NVARCHAR(50),  -- Chức vụ
    SDT_NV CHAR(10),  -- Số điện thoại nhân viên
    NGAYSINH DATE,  -- Ngày sinh
    DIACHI_NV NVARCHAR(255)  -- Địa chỉ nhân viên
);

INSERT INTO NHANVIEN (MA_NV, TENNV,GIOITINH, CHUCVU, SDT_NV, NGAYSINH, DIACHI_NV)
VALUES
('NV010', N'hi', N'Nam', N'Nhân viên bán hàng', '0987654321', '2000-09-09', N'Cao Bằng'),
('NV001', N'Trần Văn A',	N'Nam',		 N'Quản lý',			'0909876543', '1985-05-15', N'123 Hoàng Diệu, Hà Nội'),
('NV002', N'Nguyễn Thị B',	N'Nữ',		 N'Nhân viên bán hàng', '0918765432', '1990-11-20', N'234 Hùng Vương, TP.HCM'),
('NV003', N'Lê Văn C',		N'Nam',		 N'Nhân viên kỹ thuật', '0927654321', '1988-09-30', N'456 Trần Phú, Đà Nẵng');

CREATE TABLE TAIKHOAN_NV (
    MA_NV CHAR(6) PRIMARY KEY,  -- Mã nhân viên (khóa ngoại từ bảng NHANVIEN)
    PASS NVARCHAR(50) NOT NULL,  -- Mật khẩu
	IS_ACTIVE BIT DEFAULT 1,
    FOREIGN KEY (MA_NV) REFERENCES NHANVIEN(MA_NV)  -- Khóa ngoại tham chiếu đến bảng NHANVIEN
);

INSERT INTO TAIKHOAN_NV (MA_NV, PASS, IS_ACTIVE)
VALUES
('NV010','NV09', 1),
('NV001', '111111', 1),
('NV002', '101010', 1),
('NV003', '123123', 1);

select * from TAIKHOAN_NV

CREATE TABLE HD_NHAP (
    MAHD_NHAP CHAR(8) PRIMARY KEY,  -- Mã hóa đơn nhập (độ dài tối đa 8 ký tự)
    MA_NCC CHAR(6) NOT NULL,  -- Mã nhà cung cấp (khóa ngoại từ bảng NHACUNGCAP)
    MA_NV CHAR(6) NOT NULL,  -- Mã nhân viên (khóa ngoại từ bảng NHANVIEN)
    TONGBILL_NHAP DECIMAL(18,2),  -- Tổng số tiền hóa đơn nhập
    NGAYNHAP DATE NOT NULL,  -- Ngày nhập hàng
    FOREIGN KEY (MA_NCC) REFERENCES NHACUNGCAP(MA_NCC),
    FOREIGN KEY (MA_NV) REFERENCES NHANVIEN(MA_NV)
);
INSERT INTO HD_NHAP (MAHD_NHAP, MA_NCC, MA_NV, TONGBILL_NHAP, NGAYNHAP)
VALUES
('HDN007', 'NCC001', 'NV001', 1000, '2024-12-25'),
('HDN002', 'NCC001', 'NV001', 100000, '2024-10-25'),
('HDN003', 'NCC002', 'NV002', 200000, '2024-10-26'),
('HDN004', 'NCC003', 'NV002', 45000, '2024-10-27'),
('HDN005', 'NCC004', 'NV003', 457000, '2024-10-28'),
('HDN006', 'NCC005', 'NV001', 1237680, '2024-10-29');
SELECT * FROM HD_NHAP

CREATE TABLE CTHD_NHAP (
    MAHD_NHAP CHAR(8),  -- Mã hóa đơn nhập (khóa ngoại từ bảng HD_NHAP)
    MA_SP CHAR(6),  -- Mã sản phẩm (khóa ngoại từ bảng SANPHAM)
    SL_NHAP INT NOT NULL,  -- Số lượng nhập
    GIA_SP DECIMAL(18,2),  -- Giá sản phẩm (SL_NHAP * GIA_NHAP)
    FOREIGN KEY (MAHD_NHAP) REFERENCES HD_NHAP(MAHD_NHAP),
    FOREIGN KEY (MA_SP) REFERENCES SANPHAM(MA_SP)
);
INSERT INTO CTHD_NHAP (MAHD_NHAP, MA_SP, SL_NHAP, GIA_SP)
VALUES
('HDN006', 'SP001', 20, NULL),  -- Trigger sẽ tính giá
('HDN002', 'SP002', 15, NULL),
('HDN003', 'SP003', 10, NULL),
('HDN004', 'SP004', 25, NULL),
('HDN005', 'SP005', 12, NULL);
SELECT * FROM CTHD_NHAP

CREATE TABLE HD_XUAT_BAOHANH (
    MAHD_XUAT CHAR(8) PRIMARY KEY,  -- Mã hóa đơn xuất (độ dài tối đa 8 ký tự)
    SDT_KH CHAR(10) NOT NULL,  -- Số điện thoại khách hàng (khóa ngoại từ bảng KHACHHANG)
    MA_NV CHAR(6) NOT NULL,  -- Mã nhân viên (khóa ngoại từ bảng NHANVIEN)
    TONGBILL_XUAT DECIMAL(18,2),  -- Tổng số tiền hóa đơn xuất
    PHUONGTHUCGIAODICH NVARCHAR(50),  -- Phương thức giao dịch
    NGAYXUAT DATE NOT NULL,  -- Ngày xuất hàng
    FOREIGN KEY (SDT_KH) REFERENCES KHACHHANG(SDT_KH),
    FOREIGN KEY (MA_NV) REFERENCES NHANVIEN(MA_NV)
);
INSERT INTO HD_XUAT_BAOHANH (MAHD_XUAT, SDT_KH, MA_NV, TONGBILL_XUAT, PHUONGTHUCGIAODICH, NGAYXUAT)
VALUES
('HDX009', '0901234567', 'NV002', 60, N'Tiền mặt', '2024-12-30'),
('HDX004', '0901234567', 'NV002', 1236560, N'Tiền mặt', '2024-10-30'),
('HDX005', '0934567890', 'NV003', 123120, N'Chuyển khoản', '2024-10-31'),
('HDX006', '0945678901', 'NV002', 7789900, N'Tiền mặt', '2024-11-01'),
('HDX007', '0912345678', 'NV001', 2300000, N'Chuyển khoản', '2024-11-02'),
('HDX008', '0923456789', 'NV003', 3000000, N'Tiền mặt', '2024-11-03');
SELECT * FROM HD_XUAT_BAOHANH

CREATE TABLE CTHD_XUAT (
    MAHD_XUAT CHAR(8),  -- Mã hóa đơn xuất (khóa ngoại từ bảng HD_XUAT)
    MA_SP CHAR(6),  -- Mã sản phẩm (khóa ngoại từ bảng SANPHAM)
	SOLAN_XUAT INT, --Số lần xuất hoá đơn( 1 hoá đơn có thể xuất 2,3 lần)
    SL_SANPHAM INT NOT NULL,  -- Số lượng sản phẩm
    GIA_SP DECIMAL(18,2),  -- Giá sản phẩm (SL_SANPHAM * GIA_BAN)
	NGAY_BD DATE,  -- Ngày bắt đầu bảo hành và xuất sản phẩm
    NGAY_KT DATE,  -- Ngày kết thúc bảo hành
    FOREIGN KEY (MAHD_XUAT) REFERENCES HD_XUAT_BAOHANH(MAHD_XUAT),
    FOREIGN KEY (MA_SP) REFERENCES SANPHAM(MA_SP)
);
INSERT INTO CTHD_XUAT (MAHD_XUAT, MA_SP, SOLAN_XUAT, SL_SANPHAM, GIA_SP, NGAY_BD, NGAY_KT)
VALUES
('HDX008', 'SP001', 2, 1,NULL, '2024-11-03', DATEADD(MONTH, 36, '2027-11-03')),
('HDX004', 'SP002', 1, 1,NULL, '2024-10-30', DATEADD(MONTH, 36, '2027-10-30')),
('HDX005', 'SP003', 2, 1,NULL, '2024-10-31', DATEADD(MONTH, 36, '2027-10-31')),
('HDX006', 'SP004', 4, 1,NULL, '2024-11-01', DATEADD(MONTH, 36, '2027-11-01')),
('HDX007', 'SP005', 2, 1,NULL, '2024-11-02', DATEADD(MONTH, 36, '2027-11-02'));
SELECT * FROM CTHD_XUAT

--CREATE TRIGGER trg_UpdateNgayBD
--ON CTHD_XUAT
--AFTER INSERT
--AS
--BEGIN
--    -- Chèn bản ghi mới vào bảng SPBAOHANG với MA_SP, SDT_KH, MAHD_XUAT, NGAY_BD và NGAY_KT
--    INSERT INTO SPBAOHANG (MA_SP, SDT_KH, MAHD_XUAT, NGAY_BD, NGAY_KT)
--    SELECT 
--        inserted.MA_SP, 
--        HD_XUAT_BAOHANH.SDT_KH,  -- Lấy số điện thoại khách hàng từ bảng HD_XUAT
--        inserted.MAHD_XUAT, 
--        HD_XUAT_BAOHANH.NGAYXUAT AS NGAY_BD,  -- Lấy ngày xuất làm ngày bắt đầu bảo hành
--        DATEADD(MONTH, SANPHAM.TGBAOHANH, HD_XUAT_BAOHANH.NGAYXUAT) AS NGAY_KT  -- Tính ngày kết thúc bảo hành
--    FROM inserted
--    JOIN HD_XUAT_BAOHANH ON inserted.MAHD_XUAT = HD_XUAT_BAOHANH.MAHD_XUAT
--    JOIN SANPHAM ON inserted.MA_SP = SANPHAM.MA_SP;
--END;
--CREATE TRIGGER TRG_UPDATE_GIA_SP
--ON CTHD_NHAP
--FOR INSERT
--AS
--BEGIN
--    UPDATE CTHD_NHAP
--    SET GIA_SP = i.SL_NHAP * s.GIA_NHAP
--    FROM INSERTED i
--    JOIN SANPHAM s ON i.MA_SP = s.MA_SP
--    WHERE CTHD_NHAP.MAHD_NHAP = i.MAHD_NHAP
--      AND CTHD_NHAP.MA_SP = i.MA_SP;
--END;
--CREATE TRIGGER TRG_UPDATE_SOLUONG_SP
--ON CTHD_XUAT
--AFTER INSERT
--AS
--BEGIN
--    -- Giảm số lượng sản phẩm trong bảng SANPHAM khi có sản phẩm được xuất ra
--    UPDATE SANPHAM
--    SET SOLUONG_SP = SOLUONG_SP - i.SL_SANPHAM
--    FROM SANPHAM s
--    JOIN INSERTED i ON s.MA_SP = i.MA_SP
--    WHERE s.MA_SP = i.MA_SP;
--END;
--CREATE TRIGGER TRG_UPDATE_GIA_SP_XUAT
--ON CTHD_XUAT
--AFTER INSERT, UPDATE
--AS
--BEGIN
--    -- Cập nhật GIA_SP sau khi chèn hoặc cập nhật vào bảng CTHD_XUAT
--    UPDATE CTHD_XUAT
--    SET GIA_SP = i.SL_SANPHAM * s.GIA_BAN
--    FROM CTHD_XUAT c
--    JOIN SANPHAM s ON c.MA_SP = s.MA_SP
--    JOIN INSERTED i ON c.MAHD_XUAT = i.MAHD_XUAT AND c.MA_SP = i.MA_SP;
--END;
--CREATE TRIGGER TRG_UPDATE_TONGBILL_XUAT
--ON CTHD_XUAT
--AFTER INSERT, UPDATE, DELETE
--AS
--BEGIN
--    -- Cập nhật tổng bill sau khi thêm, cập nhật hoặc xóa chi tiết hóa đơn xuất
--    UPDATE HD_XUAT_BAOHANH
--    SET TONGBILL_XUAT = (
--        SELECT SUM(GIA_SP)
--        FROM CTHD_XUAT
--        WHERE CTHD_XUAT.MAHD_XUAT = HD_XUAT_BAOHANH.MAHD_XUAT
--    )
--    WHERE HD_XUAT_BAOHANH.MAHD_XUAT IN (
--        -- Lấy mã hóa đơn từ các thao tác chèn, cập nhật hoặc xóa
--        SELECT MAHD_XUAT FROM INSERTED
--        UNION
--        SELECT MAHD_XUAT FROM DELETED
--    );
--END;


--INSERT INTO CTHD_XUAT (MAHD_XUAT, MA_SP, SL_SANPHAM)
--VALUES ('HDX001', 'SP008', 10);

--SELECT * FROM SANPHAM;
--SELECT * FROM CTHD_NHAP;
--select * from HD_XUAT_BAOHANH;
--select * from CTHD_XUAT;
--INSERT INTO CTHD_NHAP (MAHD_NHAP, MA_SP, SL_NHAP)
--VALUES ('HDN001', 'SP001', 10);
--SELECT * FROM CTHD_NHAP WHERE MAHD_NHAP = 'HDN001';
--INSERT INTO HD_NHAP (MAHD_NHAP, MA_NCC, MA_NV, TONGBILL_NHAP, NGAYNHAP)
--VALUES ('HDN001', 'NCC001', 'NV001', 0, '2024-10-20');

--INSERT INTO HD_XUAT_BAOHANH (MAHD_XUAT, SDT_KH, MA_NV, TONGBILL_XUAT, PHUONGTHUCGIAODICH, NGAYXUAT)
--VALUES ('HDX002', '0901234567', 'NV001', 35000000, N'Tiền mặt', '2024-10-12');

--INSERT INTO HD_XUAT_BAOHANH (MAHD_XUAT, SDT_KH, MA_NV, TONGBILL_XUAT, PHUONGTHUCGIAODICH, NGAYXUAT)
--VALUES ('HDX003', '0934567890', 'NV002', 35000000, N'Tiền mặt', '2024-10-10');

--INSERT INTO CTHD_XUAT (MAHD_XUAT, MA_SP, SL_SANPHAM, GIA_SP)
--VALUES ('HDX002', 'SP001', 1, 35000000);
--INSERT INTO CTHD_XUAT (MAHD_XUAT, MA_SP, SL_SANPHAM, GIA_SP)
--VALUES ('HDX003', 'SP002', 1, 35000000),('HDX003', 'SP003', 2, 35000000);
--SELECT * FROM SPBAOHANG;
--SELECT * FROM CTHD_XUAT;

--CREATE TRIGGER TRG_UPDATE_TONGBILL_NHAP
--ON CTHD_NHAP
--AFTER INSERT, UPDATE, DELETE
--AS
--BEGIN
--    -- Cập nhật tổng bill sau khi thêm, cập nhật hoặc xóa chi tiết hóa đơn nhập
--    UPDATE HD_NHAP
--    SET TONGBILL_NHAP = (
--        SELECT SUM(GIA_SP)
--        FROM CTHD_NHAP
--        WHERE CTHD_NHAP.MAHD_NHAP = HD_NHAP.MAHD_NHAP
--    )
--    WHERE HD_NHAP.MAHD_NHAP IN (
--        -- Lấy mã hóa đơn từ các thao tác chèn, cập nhật hoặc xóa
--        SELECT MAHD_NHAP FROM INSERTED
--        UNION
--        SELECT MAHD_NHAP FROM DELETED
--    );
--END;
--CREATE TRIGGER TRG_UPDATE_SOLUONG_SP_NHAP
--ON CTHD_NHAP
--AFTER INSERT, UPDATE
--AS
--BEGIN
--    -- Cập nhật số lượng sản phẩm sau khi thêm hoặc cập nhật chi tiết hóa đơn nhập
--    UPDATE SANPHAM
--    SET SOLUONG_SP = SOLUONG_SP + i.SL_NHAP
--    FROM SANPHAM s
--    JOIN INSERTED i ON s.MA_SP = i.MA_SP;
--END;
--INSERT INTO CTHD_NHAP (MAHD_NHAP, MA_SP, SL_NHAP)
--VALUES ('HDN001', 'SP004', 10);

--INSERT INTO CTHD_NHAP (MAHD_NHAP, MA_SP, SL_NHAP)
--VALUES ('HDN001', 'SP008', 5);



SELECT SUM(TONGBILL_XUAT) FROM HD_XUAT_BAOHANH WHERE MONTH(NGAYXUAT) = 11 AND YEAR(NGAYXUAT) = 2024