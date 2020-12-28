-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Máy chủ: 127.0.0.1
-- Thời gian đã tạo: Th12 27, 2020 lúc 11:01 AM
-- Phiên bản máy phục vụ: 10.4.14-MariaDB
-- Phiên bản PHP: 7.4.10

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Cơ sở dữ liệu: `myweb`
--

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `admins`
--

CREATE TABLE `admins` (
  `admin_id` int(10) NOT NULL,
  `admin_name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `admin_email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `admin_pass` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `admin_image` text COLLATE utf8_unicode_ci NOT NULL,
  `admin_country` text COLLATE utf8_unicode_ci NOT NULL,
  `admin_contact` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `admin_job` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `admins`
--

INSERT INTO `admins` (`admin_id`, `admin_name`, `admin_email`, `admin_pass`, `admin_image`, `admin_country`, `admin_contact`, `admin_job`) VALUES
(1, 'Huy Nguyen', 'nguyenquochuyhbt@gmail.com', '123456789', 'admin.jpg', 'Viet Nam', '0375119131', 'Web Developer'),
(2, 'Long Phan', 'phanthanhlong@gmail.com', '123456789', 'long.jpg', 'Viet Nam', '123456789', 'Web Designer');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `boxes_section`
--

CREATE TABLE `boxes_section` (
  `box_id` int(10) NOT NULL,
  `box_title` text COLLATE utf8_unicode_ci NOT NULL,
  `box_desc` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `boxes_section`
--

INSERT INTO `boxes_section` (`box_id`, `box_title`, `box_desc`) VALUES
(3, 'Giá tốt nhất', 'Giá ưu đãi'),
(4, 'Freeship', 'Miễn phí chi phí vận chuyển'),
(5, '100% chính hãng', 'Các sản phẩm chính hãng 100%');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `cart`
--

CREATE TABLE `cart` (
  `p_id` int(10) NOT NULL,
  `ip_add` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `qty` int(10) NOT NULL,
  `size` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `categories`
--

CREATE TABLE `categories` (
  `cat_id` int(10) NOT NULL,
  `cat_title` text COLLATE utf8_unicode_ci NOT NULL,
  `cat_top` text COLLATE utf8_unicode_ci NOT NULL,
  `cat_image` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `categories`
--

INSERT INTO `categories` (`cat_id`, `cat_title`, `cat_top`, `cat_image`) VALUES
(1, '     Nam     ', 'yes', 'men.jpg'),
(2, 'Nữ', 'yes', 'women.jpg'),
(3, 'Unisex', 'yes', 'unisex.jpg'),
(4, 'Kids', 'yes', 'kids.jpg');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `customers`
--

CREATE TABLE `customers` (
  `customer_id` int(10) NOT NULL,
  `customer_name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `customer_email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `customer_pass` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `customer_contact` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `customer_address` text COLLATE utf8_unicode_ci NOT NULL,
  `customer_image` text COLLATE utf8_unicode_ci NOT NULL DEFAULT 'customer.jpg',
  `customer_ip` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `customers`
--

INSERT INTO `customers` (`customer_id`, `customer_name`, `customer_email`, `customer_pass`, `customer_contact`, `customer_address`, `customer_image`, `customer_ip`) VALUES
(1, 'Võ Hữu Anh', 'vohuuanh@gmail.com', '12345', '0945592179', 'Phan Chu Trinh', 'huuanh.jpg', '::1'),
(4, 'Phan Thành Long', 'longpt08@gmail.com', '123456789', '0386608624', 'abc', '34a5ce2d12c233bade6ac8b4465f9b57.jpg', '::1'),
(14, 'Phan Thành Long', 'test', '123', '0386608624', 'KTX khu B, ĐHQG TP.HCM', '\"customer.jpg\'', ''),
(16, 'Phan Thành Long', 'abc', '123', '123123', 'adsgadg', 'customer.jpg', '');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `customer_orders`
--

CREATE TABLE `customer_orders` (
  `order_id` int(10) NOT NULL,
  `customer_id` int(10) NOT NULL,
  `due_amount` int(100) NOT NULL,
  `invoice_no` int(11) NOT NULL,
  `qty` int(10) NOT NULL,
  `size` text COLLATE utf8_unicode_ci NOT NULL,
  `order_date` date NOT NULL,
  `order_status` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `customer_orders`
--

INSERT INTO `customer_orders` (`order_id`, `customer_id`, `due_amount`, `invoice_no`, `qty`, `size`, `order_date`, `order_status`) VALUES
(15, 12, 250000, 409420290, 1, 'Small', '2020-12-23', 'Hoàn tất'),
(16, 14, 375000, 1587058872, 1, '', '2020-12-27', 'Đang chờ xử lý');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `manufacturers`
--

CREATE TABLE `manufacturers` (
  `manufacturer_id` int(10) NOT NULL,
  `manufacturer_title` text COLLATE utf8_unicode_ci NOT NULL,
  `manufacturer_top` text COLLATE utf8_unicode_ci NOT NULL,
  `manufacturer_image` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `manufacturers`
--

INSERT INTO `manufacturers` (`manufacturer_id`, `manufacturer_title`, `manufacturer_top`, `manufacturer_image`) VALUES
(10, 'Senka', 'yes', 'senka.jpg'),
(11, 'SOME BY MI', 'yes', 'somebymi.jpg'),
(12, 'La Roche-Posay', 'yes', 'larocheposay.jpg'),
(13, 'Biore', 'yes', 'biore.jpg'),
(14, 'Estee Lauder', 'yes', 'esteelauder.jpg'),
(15, 'Clinique', 'yes', 'clinique.jpg'),
(16, 'The Ordinary', 'yes', 'theordinary.jpg'),
(17, 'Paulas Choice', 'yes', 'paulaschoice.jpg');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `payments`
--

CREATE TABLE `payments` (
  `payment_id` int(10) NOT NULL,
  `invoice_no` int(10) NOT NULL,
  `amount` int(10) NOT NULL,
  `payment_date` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `payments`
--

INSERT INTO `payments` (`payment_id`, `invoice_no`, `amount`, `payment_date`) VALUES
(7, 409420290, 250000, '2020-12-23');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `pending_orders`
--

CREATE TABLE `pending_orders` (
  `order_id` int(10) NOT NULL,
  `customer_id` int(10) NOT NULL,
  `invoice_no` int(10) NOT NULL,
  `product_id` int(10) NOT NULL,
  `qty` int(10) NOT NULL,
  `size` text COLLATE utf8_unicode_ci NOT NULL,
  `order_status` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `pending_orders`
--

INSERT INTO `pending_orders` (`order_id`, `customer_id`, `invoice_no`, `product_id`, `qty`, `size`, `order_status`) VALUES
(17, 14, 1587058872, 19, 1, '', 'Đang chờ xử lý');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `products`
--

CREATE TABLE `products` (
  `product_id` int(10) NOT NULL,
  `p_cat_id` int(10) NOT NULL,
  `cat_id` int(10) NOT NULL,
  `manufacturer_id` int(10) NOT NULL,
  `date` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp(),
  `product_title` text COLLATE utf8_unicode_ci NOT NULL,
  `product_img` text COLLATE utf8_unicode_ci NOT NULL,
  `product_price` int(10) NOT NULL,
  `product_keywords` text COLLATE utf8_unicode_ci NOT NULL,
  `product_desc` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `products`
--

INSERT INTO `products` (`product_id`, `p_cat_id`, `cat_id`, `manufacturer_id`, `date`, `product_title`, `product_img`, `product_price`, `product_keywords`, `product_desc`) VALUES
(8, 16, 3, 15, '2020-12-15 07:47:40', 'Kem Dưỡng Clinique Cấp Ẩm, Làm Sáng Cho Da Dầu 50ml', 'kemduong_clinique.jpg', 250000, 'kemduong', '<p><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">L&agrave;m s&aacute;ng da v&agrave; t&aacute;i tạo da</span><br style=\"box-sizing: border-box; color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\" /><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">Gi&uacute;p da mềm mại, trắng s&aacute;ng tự nhi&ecirc;n, tr&agrave;n đầy sức sống</span><br style=\"box-sizing: border-box; color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\" /><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">Thẩm thấu nhanh v&agrave;o da, l&agrave;m dịu m&aacute;t, kh&ocirc;ng g&acirc;y ngứa v&agrave; bết d&iacute;nh</span><br style=\"box-sizing: border-box; color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\" /><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">Dưỡng ẩm da gi&uacute;p da săn chắc, s&aacute;ng hồng, trẻ h&oacute;a l&agrave;n da</span><br style=\"box-sizing: border-box; color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\" /><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">Cải thiện l&agrave;n da bị n&aacute;m, kh&ocirc; sần, chống l&atilde;o h&oacute;a</span><br style=\"box-sizing: border-box; color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\" /><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">Giảm thiểu c&aacute;c dấu hiệu mệt mỏi, căng thẳng cho daGel Dưỡng Ẩm D&agrave;nh Cho Da Dầu, Hỗn Hợp Dầu Dramatically Different Moisturizing Gel - Clinique gi&uacute;p l&agrave;m s&aacute;ng da v&agrave; t&aacute;i tạo da</span><br style=\"box-sizing: border-box; color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\" /><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">Gi&uacute;p da mềm mại, trắng s&aacute;ng tự nhi&ecirc;n, tr&agrave;n đầy sức sống</span><br style=\"box-sizing: border-box; color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\" /><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">Thẩm thấu nhanh v&agrave;o da, l&agrave;m dịu m&aacute;t, kh&ocirc;ng g&acirc;y ngứa v&agrave; bết d&iacute;nh</span><br style=\"box-sizing: border-box; color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\" /><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">Dưỡng ẩm da gi&uacute;p da săn chắc, s&aacute;ng hồng, trẻ h&oacute;a l&agrave;n da</span><br style=\"box-sizing: border-box; color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\" /><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">Cải thiện l&agrave;n da bị n&aacute;m, kh&ocirc; sần, chống l&atilde;o h&oacute;a</span><br style=\"box-sizing: border-box; color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\" /><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">Giảm thiểu c&aacute;c dấu hiệu mệt mỏi, căng thẳng cho da</span><br style=\"box-sizing: border-box; color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\" /><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">C&aacute;c sản phẩm của ch&uacute;ng t&ocirc;i được ph&aacute;t triển trong m&ocirc;i trường ph&ograve;ng th&iacute; nghiệm v&agrave; sản xuất trong qui tr&igrave;nh hiện đại được quản l&iacute; nghi&ecirc;m ngặt.</span><br style=\"box-sizing: border-box; color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\" /><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">Clinique đảm bảo kh&ocirc;ng thử nghiệm sản phẩm tr&ecirc;n động vật theo ch&iacute;nh s&aacute;ch ti&ecirc;u chuẩn của Hoa K&igrave;.</span></p>'),
(9, 16, 3, 17, '2020-12-27 05:23:39', 'Kem Dưỡng Clinique Cấp Ẩm, Làm Sáng Cho Da Dầu 50ml', 'kemduong_paulaschoice.jpg', 690000, 'kemduong', '<p><strong style=\"box-sizing: border-box; font-family: arial, helvetica, sans-serif; font-size: 13px;\">Kem Dưỡng Ẩm D&agrave;nh Cho Da Mụn Paulas Choice&nbsp;Clear Oil-Free Moisturizer&nbsp;60ml&nbsp;</strong><span style=\"box-sizing: border-box; font-family: arial, helvetica, sans-serif; font-size: 13px;\">l&agrave;&nbsp;</span><a style=\"box-sizing: border-box; color: #326d52; text-decoration-line: none; outline: none; font-weight: bold; font-family: arial, helvetica, sans-serif; font-size: 13px;\" href=\"https://hasaki.vn/danh-muc/kem-duong-da-c9.html\" target=\"_blank\" rel=\"noopener\"><span style=\"box-sizing: border-box; color: #003300;\"><strong style=\"box-sizing: border-box;\">kem dưỡng</strong></span></a><span style=\"box-sizing: border-box; font-family: arial, helvetica, sans-serif; font-size: 13px;\">&nbsp;thuộc&nbsp;</span><a style=\"box-sizing: border-box; color: #326d52; text-decoration-line: none; outline: none; font-weight: bold; font-family: arial, helvetica, sans-serif; font-size: 13px;\" href=\"https://hasaki.vn/thuong-hieu/paula-s-choice.html\" target=\"_blank\" rel=\"noopener\"><span style=\"box-sizing: border-box; color: #003300;\"><strong style=\"box-sizing: border-box;\">thương hiệu dược mỹ phẩm Paulas Choice</strong></span></a><span style=\"box-sizing: border-box; font-family: arial, helvetica, sans-serif; font-size: 13px;\">&nbsp;nổi tiếng từ Mỹ, với c&ocirc;ng thức ho&agrave;n to&agrave;n kh&ocirc;ng chứa dầu, được chiết xuất từ c&aacute;c th&agrave;nh phần thi&ecirc;n nhi&ecirc;n dịu nhẹ, ph&ugrave; hợp cho l&agrave;n da mụn sưng vi&ecirc;m, gi&uacute;p cung cấp&nbsp;</span><span style=\"box-sizing: border-box; font-family: arial, helvetica, sans-serif; font-size: 13px;\">độ ẩm cần thiết cho da m&agrave; kh&ocirc;ng g&acirc;y b&iacute;t tắc lỗ ch&acirc;n l&ocirc;ng, đồng thời&nbsp;ngăn ngừa t&igrave;nh trạng tăng tiết dầu v&agrave; giảm thiểu t&aacute;c nh&acirc;n g&acirc;y n&ecirc;n mụn.</span></p>'),
(10, 16, 3, 11, '2020-12-27 05:26:44', 'Kem Dưỡng Some By Mi Làm Giảm Và Ngăn Ngừa Mụn 60g', 'google-shopping-kem-duong-some-by-mi-lam-giam-va-ngan-ngua-mun-60g_img_80x80_d200c5_fit_center.jpg', 230000, 'kemduong,somebymi,kem dưỡng, mụn', '<p><strong style=\"box-sizing: border-box; font-family: arial, helvetica, sans-serif; font-size: 13px;\"><a style=\"box-sizing: border-box; color: #326d52; text-decoration-line: none; background-color: transparent; outline: none;\" href=\"https://hasaki.vn/danh-muc/da-mun-tham-c16.html\" target=\"_blank\" rel=\"noopener\">Kem Dưỡng Giảm Mụn</a>&nbsp;Some By Mi</strong><span style=\"font-family: arial, helvetica, sans-serif; font-size: 13px;\">&nbsp;c&oacute; chứa th&agrave;nh phần chứa AHA, BHA, PHA l&agrave; c&aacute;c th&agrave;nh phần cực kỳ quan trọng trong việc chăm s&oacute;c da hiện nay. C&aacute;c th&agrave;nh phần n&agrave;y sẽ gi&uacute;p l&agrave;m bong lớp da chết, l&agrave;m sạch da, kh&aacute;ng vi&ecirc;m, giảm nguy cơ g&acirc;y ra mụn. Hơn thế nữa, sản phẩm c&ograve;n gi&uacute;p th&uacute;c đẩy tế b&agrave;o da t&aacute;i tạo, giảm nếp nhăn, gi&uacute;p ngăn ngừa l&atilde;o h&oacute;a v&agrave; nu&ocirc;i dưỡng da săn chắc, khỏe mạnh. Kem c&oacute; dạng gel ẩm, hấp thụ v&agrave;o da nhanh ch&oacute;ng, kh&ocirc;ng g&acirc;y bết d&iacute;nh hay b&oacute;ng nhờn, kh&ocirc;ng l&agrave;m nặng mặt, mang lại cảm gi&aacute;c tươi m&aacute;t khi sử dụng</span></p>'),
(11, 18, 3, 14, '2020-12-27 05:34:28', 'Tinh chất chống lão hóa Estée Lauder Advanced Night Repair Synchronized Recovery Complex II 50ML', 'estee.jfif', 1500000, 'serum, estee lauder', '<p><span style=\"color: #666666; font-family: Tinos, Arial, Helvetica, sans-serif; font-size: 20px;\">Est&eacute;e Lauder l&agrave; một trong những nh&atilde;n hiệu l&agrave;m đẹp nổi tiếng nhất thế giới, tinh tế về sự đổi mới, vượt trội về chất lượng.&nbsp; Tinh chất chống l&atilde;o h&oacute;a Advanced Night Repair l&agrave; d&ograve;ng kem dưỡng da của Est&eacute;e Lauder. Sở hữu c&aacute;c th&agrave;nh phần dưỡng chất c&oacute; lợi cho da, tinh chất chống l&atilde;o h&oacute;a&nbsp;</span><span style=\"box-sizing: border-box; margin: 0px; padding: 0px; outline: none; font-weight: bold; max-width: 100%; color: #666666; font-family: Tinos, Arial, Helvetica, sans-serif; font-size: 20px;\"><a style=\"box-sizing: border-box; margin: 0px; padding: 0px; outline: none; background-color: transparent; text-decoration-line: none; max-width: 100%; color: #666666 !important;\" href=\"http://thegioisonmoi.com/products/tinh-chat-chong-lao-hoa-estee-lauder-advanced-night-repair-synchronized-recovery-complex-ii\">Est&eacute;e Lauder Advanced Night Repair</a></span><span style=\"color: #666666; font-family: Tinos, Arial, Helvetica, sans-serif; font-size: 20px;\">&nbsp;Synchronized Recovery Complex II t&aacute;c động v&agrave;o s&acirc;u b&ecirc;n trong k&iacute;ch th&iacute;ch sự trao đổi chất v&agrave; tăng cường hoạt động của tế b&agrave;o, l&agrave;m giảm qu&aacute; tr&igrave;nh oxy ho&aacute;, chống lại c&aacute;c dấu hiệu l&atilde;o ho&aacute; như nếp nhăn, da kh&ocirc;, quầng th&acirc;m, vết n&aacute;m, sạm; tinh chất mới ưu việt thấm s&acirc;u nu&ocirc;i dưỡng l&agrave;n da, l&agrave;m mềm da, th&uacute;c đẩy qu&aacute; tr&igrave;nh phục hồi tự nhi&ecirc;n của da trong giấc ngủ, mang lại l&agrave;n da trắng s&aacute;ng, mịn m&agrave;ng kh&ocirc;ng t&igrave; vết.</span></p>'),
(12, 18, 3, 16, '2020-12-27 05:38:59', 'Serum The Ordinary Hyaluronic Acid 2% + B5, 30ml', 'tải xuống.jfif', 300000, 'serum, the ordinary', '<p><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">The Ordinary Hyaluronic Acid 2% + B5 cấp ẩm cho da, gi&uacute;p da mềm mại, tăng độ đ&agrave;n hồi v&agrave; căng mọng. Đồng thời hiệu quả cho l&agrave;n da thiếu nước, cả da kh&ocirc; lẫn da dầu.</span></p>'),
(13, 19, 3, 10, '2020-12-27 05:40:19', 'Gel Sữa Chống Nắng Senka Perfect UV Gel N 80ml', 'tải xuống (1).jfif', 180000, 'kemchongnang, kem chống nắng, senka', '<p><span style=\"box-sizing: border-box; margin: 0px; padding: 0px; font-family: Quicksand, sans-serif; font-weight: bold; font-size: 14.6667px; color: #222222;\">Gel Sữa Chống Nắng Senka Perfect UV Gel N 80ml&nbsp;</span><span style=\"color: #222222; font-family: Quicksand, sans-serif; font-size: 14.6667px;\">gi&uacute;p bảo vệ da khỏi t&aacute;c hại của tia UV, chỉ số chống nắng cao gi&uacute;p che chắn v&agrave; bảo vệ da khỏi tia tử ngoại c&oacute; hại. Ngo&agrave;i ra, gel chống nắng gi&agrave;u chất dưỡng ẩm cho về mặt da lu&ocirc;n tươi s&aacute;ng rạng rỡ, ẩm mịn v&agrave; mềm mượt. Với kết cấu dạng gel sữa mỏng nhẹ dễ d&agrave;ng thẩm thấu tr&ecirc;n da, kh&ocirc;ng nhờn r&iacute;t, mang lại cảm gi&aacute;c m&aacute;t mẻ, kh&ocirc; r&aacute;o.</span></p>'),
(14, 19, 3, 12, '2020-12-27 05:41:41', 'Kem Chống Nắng Không Màu Kiểm Soát Dầu La Roche-Posay Anthelios XL Dry Touch Gel-Cream SPF 50+ UVB & UVA (50ml)', 'tải xuống (2).jfif', 375000, 'kemchongnang, kem chống nắng, la roche posay', '<p><span style=\"box-sizing: border-box; font-weight: bolder; color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">Kem Chống Nắng Kh&ocirc;ng M&agrave;u Kiểm So&aacute;t Dầu La Roche-Posay Anthelios XL Dry Touch Gel-Cream SPF 50+ UVB &amp; UVA</span><span style=\"color: #242424; font-family: Roboto, Helvetica, Arial, sans-serif; text-align: justify;\">&nbsp;l&agrave; kem chống nắng d&agrave;nh cho da dầu gi&uacute;p kiểm so&aacute;t b&oacute;ng nhờn v&agrave; bảo vệ da trước t&aacute;c hại từ &aacute;nh nắng &amp; &ocirc; nhiễm, ngăn chặn c&aacute;c t&aacute;c nh&acirc;n g&acirc;y l&atilde;o h&oacute;a sớm. Sản phẩm c&oacute; c&ocirc;ng thức chống thấm nước th&iacute;ch hợp d&ugrave;ng h&agrave;ng ng&agrave;y v&agrave; cả những hoạt động ngo&agrave;i trời, để bạn lu&ocirc;n tự tin tỏa s&aacute;ng.</span></p>'),
(15, 21, 3, 13, '2020-12-27 05:44:36', 'Sữa Rửa Mặt Bioré Sạch Mụn & Kháng Khuẩn 100g', 'tải xuống (3).jfif', 45000, 'sữa rửa mặt, biore', '<p><strong style=\"box-sizing: border-box; font-family: arial, helvetica, sans-serif; font-size: 13px;\">Sữa Rửa Mặt Bior&eacute; Kh&aacute;ng Khuẩn &amp; Sạch Mụn</strong><span style=\"font-family: arial, helvetica, sans-serif; font-size: 13px;\">&nbsp;được xem l&agrave; b&iacute; quyết sở hữu l&agrave;n da mộc đẹp tự nhi&ecirc;n của phụ nữ Nhật Bản. Sản phẩm chứa hoạt chất kh&aacute;ng khuẩn o-Cymen-5-ol gi&uacute;p ngăn ngừa vi khuẩn g&acirc;y mụn một c&aacute;ch hiệu quả. C&ocirc;ng nghệ thanh lọc da SPT đột ph&aacute; từ Nhật Bản, n&oacute; hoạt động như nam ch&acirc;m th&ocirc;ng minh lấy sạch mọi bụi bẩn, b&atilde; nhờn tr&ecirc;n bề mặt da m&agrave; kh&ocirc;ng l&agrave;m mất đi độ ẩm tự nhi&ecirc;n của da.</span></p>'),
(16, 21, 3, 12, '2020-12-27 05:46:23', 'Sữa Rửa Mặt Tạo Bọt La Roche-Posay Effaclar Cho Da Dầu Nhạy Cảm 400ml', 'tải xuống (4).jfif', 455000, 'sữa rửa mặt, la roche posay', '<p><span style=\"color: #333333; font-family: Roboto, sans-serif; font-size: 12px; text-align: justify;\">Sữa Rửa Mặt Tạo Bọt La Roche-Posay Effaclar Cho Da Dầu Nhạy Cảm gi&uacute;p l&agrave;m sạch s&acirc;u, ngăn ngừa mụn v&agrave; se kh&iacute;t lỗ ch&acirc;n l&ocirc;ng. Sữa rửa mặt dạng kem tạo bọt, gi&uacute;p l&agrave;m sạch, thanh tẩy bề mặt da.</span></p>'),
(17, 21, 3, 17, '2020-12-27 05:47:43', 'CLEAR PORE NORMALIZING CLEANSER', 'tải xuống (5).jfif', 500000, 'sữa rửa mặt, paulas choice', '<p><span style=\"color: #333133; font-family: Roboto, sans-serif; font-size: 16px; text-align: center;\">Sản phẩm sở hữu th&agrave;nh phần dịu nhẹ, loại bỏ lượng dầu thừa, da chết, tạp chất v&agrave; lớp make up m&agrave; kh&ocirc;ng khiến da kh&ocirc; hay ửng đỏ, đặc biệt ph&ugrave; hợp với l&agrave;n da mụn hay gặp vấn đề trầm trọng về dầu thừa.</span></p>'),
(18, 17, 3, 16, '2020-12-27 05:49:50', 'Nước hoa hồng Toner Glycolic Acid 7% The Ordinary', 'tải xuống (6).jfif', 275000, 'toner, the ordinary', '<p><span style=\"box-sizing: border-box; font-weight: bolder; color: #0a0a0a; font-family: Muli, sans-serif; font-size: 16px;\">The Ordinary Glycolic Acid 7% Toning Solution</span><span style=\"color: #0a0a0a; font-family: Muli, sans-serif; font-size: 16px;\">&nbsp;l&agrave; nước hoa hồng đặc trị nhẹ nh&agrave;ng tẩy da chết gi&uacute;p da được s&aacute;ng m&agrave;u v&agrave; đồng đều. Từ đ&oacute; mang lại một l&agrave;n da s&aacute;ng đều m&agrave;u v&agrave; rạng rỡ hơn.</span></p>'),
(19, 22, 3, 12, '2020-12-27 06:10:58', 'Nước Tẩy Trang La Roche-Posay Dành Cho Da Nhạy Cảm 400ml', 'tải xuống (8).jfif', 375000, 'nước tẩy trang, la roche posay', '<p><span style=\"color: #4c4c4c; font-family: Roboto, sans-serif; font-size: 15px; text-align: justify;\">Nước L&agrave;m Sạch S&acirc;u V&agrave; Tẩy Trang La Roche-Posay D&agrave;nh Cho Da Nhạy Cảm l&agrave; sản phẩm tẩy trang l&agrave;m sạch s&acirc;u được thiết kế ri&ecirc;ng cho da nhạy cảm. Với c&ocirc;ng nghệ cải tiến Glyco Micellar, sản phẩm mang lại hiệu quả l&agrave;m sạch s&acirc;u vượt trội gi&uacute;p lấy đi bụi bẩn, b&atilde; nhờn v&agrave; lớp trang điểm nhưng vẫn an to&agrave;n cho l&agrave;n da nhạy cảm &amp; dễ k&iacute;ch ứng.</span></p>');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `product_categories`
--

CREATE TABLE `product_categories` (
  `p_cat_id` int(10) NOT NULL,
  `p_cat_title` text COLLATE utf8_unicode_ci NOT NULL,
  `p_cat_top` text COLLATE utf8_unicode_ci NOT NULL,
  `p_cat_image` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `product_categories`
--

INSERT INTO `product_categories` (`p_cat_id`, `p_cat_title`, `p_cat_top`, `p_cat_image`) VALUES
(16, 'Kem dưỡng', 'yes', 'kemduong.jpg'),
(17, 'Toner', 'yes', 'toner.jpg'),
(18, 'Serum', 'yes', 'serum.jpg'),
(19, 'Kem chống nắng', 'yes', 'kemchongnang.jpg'),
(20, 'Lotion', 'yes', 'lotion.jpg'),
(21, 'Sữa rửa mặt', 'yes', 'suaruamat.jpg'),
(22, 'Nước tẩy trang', 'yes', 'nuoctaytrang.jpg');

-- --------------------------------------------------------

--
-- Cấu trúc bảng cho bảng `slider`
--

CREATE TABLE `slider` (
  `slider_id` int(10) NOT NULL,
  `slider_name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `slider_image` text COLLATE utf8_unicode_ci NOT NULL,
  `slide_url` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Đang đổ dữ liệu cho bảng `slider`
--

INSERT INTO `slider` (`slider_id`, `slider_name`, `slider_image`, `slide_url`) VALUES
(1, 'slide 1', 'hinh1_slide.jpg', 'http://localhost/myweb/cuahang.php'),
(2, 'slide 2', 'hinh2_slide.jpg', 'http://localhost/myweb/cuahang.php'),
(3, 'slide 3', 'hinh3_slide.jpg', 'http://localhost/myweb/cuahang.php'),
(4, 'slide 4', 'hinh4_slide.jpg', 'http://localhost/myweb/cuahang.php'),
(5, 'slide 5', 'hinh5_slide.jpg', 'http://localhost/myweb/cuahang.php'),
(6, 'slide 6', 'hinh6_slide.jpg', 'http://localhost/myweb/cuahang.php');

--
-- Chỉ mục cho các bảng đã đổ
--

--
-- Chỉ mục cho bảng `admins`
--
ALTER TABLE `admins`
  ADD PRIMARY KEY (`admin_id`);

--
-- Chỉ mục cho bảng `boxes_section`
--
ALTER TABLE `boxes_section`
  ADD PRIMARY KEY (`box_id`);

--
-- Chỉ mục cho bảng `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`p_id`);

--
-- Chỉ mục cho bảng `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`cat_id`);

--
-- Chỉ mục cho bảng `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`customer_id`);

--
-- Chỉ mục cho bảng `customer_orders`
--
ALTER TABLE `customer_orders`
  ADD PRIMARY KEY (`order_id`);

--
-- Chỉ mục cho bảng `manufacturers`
--
ALTER TABLE `manufacturers`
  ADD PRIMARY KEY (`manufacturer_id`);

--
-- Chỉ mục cho bảng `payments`
--
ALTER TABLE `payments`
  ADD PRIMARY KEY (`payment_id`);

--
-- Chỉ mục cho bảng `pending_orders`
--
ALTER TABLE `pending_orders`
  ADD PRIMARY KEY (`order_id`);

--
-- Chỉ mục cho bảng `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`),
  ADD KEY `fk01_pc_p` (`p_cat_id`),
  ADD KEY `fk02_c_p` (`cat_id`);

--
-- Chỉ mục cho bảng `product_categories`
--
ALTER TABLE `product_categories`
  ADD PRIMARY KEY (`p_cat_id`);

--
-- Chỉ mục cho bảng `slider`
--
ALTER TABLE `slider`
  ADD PRIMARY KEY (`slider_id`);

--
-- AUTO_INCREMENT cho các bảng đã đổ
--

--
-- AUTO_INCREMENT cho bảng `admins`
--
ALTER TABLE `admins`
  MODIFY `admin_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT cho bảng `boxes_section`
--
ALTER TABLE `boxes_section`
  MODIFY `box_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT cho bảng `categories`
--
ALTER TABLE `categories`
  MODIFY `cat_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT cho bảng `customers`
--
ALTER TABLE `customers`
  MODIFY `customer_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT cho bảng `customer_orders`
--
ALTER TABLE `customer_orders`
  MODIFY `order_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT cho bảng `manufacturers`
--
ALTER TABLE `manufacturers`
  MODIFY `manufacturer_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT cho bảng `payments`
--
ALTER TABLE `payments`
  MODIFY `payment_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT cho bảng `pending_orders`
--
ALTER TABLE `pending_orders`
  MODIFY `order_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=18;

--
-- AUTO_INCREMENT cho bảng `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT cho bảng `product_categories`
--
ALTER TABLE `product_categories`
  MODIFY `p_cat_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=23;

--
-- AUTO_INCREMENT cho bảng `slider`
--
ALTER TABLE `slider`
  MODIFY `slider_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Các ràng buộc cho các bảng đã đổ
--

--
-- Các ràng buộc cho bảng `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `fk01_pc_p` FOREIGN KEY (`p_cat_id`) REFERENCES `product_categories` (`p_cat_id`),
  ADD CONSTRAINT `fk02_c_p` FOREIGN KEY (`cat_id`) REFERENCES `categories` (`cat_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
