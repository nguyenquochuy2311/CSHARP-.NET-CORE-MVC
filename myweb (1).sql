-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 13, 2020 at 09:35 AM
-- Server version: 10.4.14-MariaDB
-- PHP Version: 7.2.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `myweb`
--

-- --------------------------------------------------------

--
-- Table structure for table `admins`
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
-- Dumping data for table `admins`
--

INSERT INTO `admins` (`admin_id`, `admin_name`, `admin_email`, `admin_pass`, `admin_image`, `admin_country`, `admin_contact`, `admin_job`) VALUES
(1, 'Huy Nguyen', 'nguyenquochuyhbt@gmail.com', '123456789', 'admin.jpg', 'Viet Nam', '0375119131', 'Web Developer'),
(2, 'Long Phan', 'phanthanhlong@gmail.com', '123456789', 'uit.jpg', 'Viet Nam', '123456789', 'Web Designer');

-- --------------------------------------------------------

--
-- Table structure for table `boxes_section`
--

CREATE TABLE `boxes_section` (
  `box_id` int(10) NOT NULL,
  `box_title` text COLLATE utf8_unicode_ci NOT NULL,
  `box_desc` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `boxes_section`
--

INSERT INTO `boxes_section` (`box_id`, `box_title`, `box_desc`) VALUES
(3, 'Giá tốt nhất', 'Giá ưu đãi'),
(4, 'Freeship', 'Miễn phí chi phí vận chuyển'),
(5, '100% chính hãng', 'Các sản phẩm chính hãng 100%');

-- --------------------------------------------------------

--
-- Table structure for table `cart`
--

CREATE TABLE `cart` (
  `p_id` int(10) NOT NULL,
  `ip_add` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `qty` int(10) NOT NULL,
  `size` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `cart`
--

INSERT INTO `cart` (`p_id`, `ip_add`, `qty`, `size`) VALUES
(6, '::1', 5, '');

-- --------------------------------------------------------

--
-- Table structure for table `categories`
--

CREATE TABLE `categories` (
  `cat_id` int(10) NOT NULL,
  `cat_title` text COLLATE utf8_unicode_ci NOT NULL,
  `cat_top` text COLLATE utf8_unicode_ci NOT NULL,
  `cat_image` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `categories`
--

INSERT INTO `categories` (`cat_id`, `cat_title`, `cat_top`, `cat_image`) VALUES
(1, 'Nam', 'yes', 'men.jpg'),
(2, 'Nữ', 'yes', 'women.jpg'),
(3, 'Unisex', 'yes', 'unisex.jpg'),
(4, 'Kids', 'yes', 'kids.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `customer_id` int(10) NOT NULL,
  `customer_name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `customer_email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `customer_pass` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `customer_country` text COLLATE utf8_unicode_ci NOT NULL,
  `customer_city` text COLLATE utf8_unicode_ci NOT NULL,
  `customer_contact` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `customer_address` text COLLATE utf8_unicode_ci NOT NULL,
  `customer_image` text COLLATE utf8_unicode_ci NOT NULL,
  `customer_ip` varchar(100) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `customers`
--

INSERT INTO `customers` (`customer_id`, `customer_name`, `customer_email`, `customer_pass`, `customer_country`, `customer_city`, `customer_contact`, `customer_address`, `customer_image`, `customer_ip`) VALUES
(1, 'Võ Hữu Anh', 'vohuuanh@gmail.com', '12345', 'Việt Nam', 'Thừa Thiên Huế', '0945592179', 'Phan Chu Trinh', 'huuanh.jpg', '::1');

-- --------------------------------------------------------

--
-- Table structure for table `customer_orders`
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
-- Dumping data for table `customer_orders`
--

INSERT INTO `customer_orders` (`order_id`, `customer_id`, `due_amount`, `invoice_no`, `qty`, `size`, `order_date`, `order_status`) VALUES
(1, 1, 790000, 1999916528, 1, '', '2020-12-02', 'Đang chờ xử lý'),
(2, 1, 980000, 1999916528, 2, 'Small', '2020-12-02', 'Hoàn tất'),
(3, 1, 1470000, 223012318, 3, 'Medium', '2020-12-02', 'Đang chờ xử lý'),
(4, 1, 980000, 484904102, 2, 'Medium', '2020-12-02', 'Đang chờ xử lý');

-- --------------------------------------------------------

--
-- Table structure for table `manufacturers`
--

CREATE TABLE `manufacturers` (
  `manufacturer_id` int(10) NOT NULL,
  `manufacturer_title` text COLLATE utf8_unicode_ci NOT NULL,
  `manufacturer_top` text COLLATE utf8_unicode_ci NOT NULL,
  `manufacturer_image` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `manufacturers`
--

INSERT INTO `manufacturers` (`manufacturer_id`, `manufacturer_title`, `manufacturer_top`, `manufacturer_image`) VALUES
(1, 'Nike', 'yes', 'nike.jpg'),
(2, 'Addidas', 'yes', 'adidas.jpg'),
(4, 'Converse', 'yes', 'converse.jpg'),
(5, 'Vans', 'yes', 'vans.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `payments`
--

CREATE TABLE `payments` (
  `payment_id` int(10) NOT NULL,
  `invoice_no` int(10) NOT NULL,
  `amount` int(10) NOT NULL,
  `payment_mode` text COLLATE utf8_unicode_ci NOT NULL,
  `ref_no` int(10) NOT NULL,
  `code` int(10) NOT NULL,
  `payment_date` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `payments`
--

INSERT INTO `payments` (`payment_id`, `invoice_no`, `amount`, `payment_mode`, `ref_no`, `code`, `payment_date`) VALUES
(1, 1999916528, 10000, '1', 12345, 12345, '2020-12-10');

-- --------------------------------------------------------

--
-- Table structure for table `pending_orders`
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
-- Dumping data for table `pending_orders`
--

INSERT INTO `pending_orders` (`order_id`, `customer_id`, `invoice_no`, `product_id`, `qty`, `size`, `order_status`) VALUES
(4, 1, 1999916528, 2, 1, '', 'Đang chờ xử lý');

-- --------------------------------------------------------

--
-- Table structure for table `products`
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
-- Dumping data for table `products`
--

INSERT INTO `products` (`product_id`, `p_cat_id`, `cat_id`, `manufacturer_id`, `date`, `product_title`, `product_img`, `product_price`, `product_keywords`, `product_desc`) VALUES
(2, 1, 2, 1, '2020-12-06 10:28:13', 'Nike Air Force 1 Low GS Triple White.\r\n\r\n ', 'g_nike2.jpg', 790000, 'giày nike', '<p>a</p>\r\n<div id=\"eJOY__extension_root\" class=\"eJOY__extension_root_class\" style=\"all: unset;\">&nbsp;</div>'),
(3, 1, 1, 1, '2020-12-06 10:28:20', 'Nike Air Jordan 1 X Off-White X Retro High OG Chicago', 'g_jordan3.jpg', 1590000, 'giày nike jordan', '<p><em style=\"box-sizing: border-box; margin: 0px; padding: 0px; border: 0px; vertical-align: baseline; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; font-family: Roboto, Arial, Helvetica, sans-serif; color: #777777;\"><span style=\"box-sizing: border-box; margin: 0px; padding: 0px; border: 0px; vertical-align: baseline; font-style: inherit; font-variant: inherit; font-weight: 600; font-stretch: inherit; line-height: inherit; font-family: inherit;\">Gi&agrave;y Off White X Air Jordan</span></em><span style=\"color: #777777; font-family: Roboto, Arial, Helvetica, sans-serif;\">&nbsp;l&agrave; một sản phẩm kết hợp xu hướng&nbsp;</span><em style=\"box-sizing: border-box; margin: 0px; padding: 0px; border: 0px; vertical-align: baseline; font-variant-numeric: inherit; font-variant-east-asian: inherit; font-stretch: inherit; line-height: inherit; font-family: Roboto, Arial, Helvetica, sans-serif; color: #777777;\"><span style=\"box-sizing: border-box; margin: 0px; padding: 0px; border: 0px; vertical-align: baseline; font-style: inherit; font-variant: inherit; font-weight: 600; font-stretch: inherit; line-height: inherit; font-family: inherit;\">Off White</span></em><span style=\"color: #777777; font-family: Roboto, Arial, Helvetica, sans-serif;\">&nbsp;đang thống trị xu thế đường phố vẫn với tinh thần Gi&agrave;y Air Jordan k&egrave;m với một số chi tiết nổi bật đặc trưng c&ugrave;a Off White. Ch&iacute;nh những điều đ&oacute; đ&atilde; mang đến n&eacute;t mới lạ cho Air Jordan.</span></p>\r\n<div id=\"eJOY__extension_root\" class=\"eJOY__extension_root_class\" style=\"all: unset;\">&nbsp;</div>'),
(5, 4, 3, 4, '2020-12-06 10:28:35', 'Biggod – Balo (Backpack) Local Brand', 'balo1.jpg', 345000, 'balo nam nữ', '<p><span style=\"color: #777777; font-family: Roboto, Arial, Helvetica, sans-serif;\">Balo nhẹ v&agrave; tho&aacute;ng, chống thấm nước, 1 ngăn lớn, nhiều ngăn phụ, c&oacute; ngăn đựng laptop. Ph&ugrave; hợp nam nữ</span></p>\r\n<div id=\"eJOY__extension_root\" class=\"eJOY__extension_root_class\" style=\"all: unset;\">&nbsp;</div>'),
(6, 2, 3, 1, '2020-12-06 10:28:38', 'Dép Nike Benassi ‘Just Do It’ Slides In White', 'd_nike2.jpg', 490000, 'dép nike', '<p>&nbsp;</p>\r\n<div id=\"eJOY__extension_root\" class=\"eJOY__extension_root_class\" style=\"all: unset;\">&nbsp;</div>'),
(8, 1, 1, 2, '2020-12-08 18:39:29', 'a', 'g_addidas.jpg', 790000, 'giày addidas', '<p>&nbsp;</p>\r\n<div id=\"eJOY__extension_root\" class=\"eJOY__extension_root_class\" style=\"all: unset;\">&nbsp;</div>');

-- --------------------------------------------------------

--
-- Table structure for table `product_categories`
--

CREATE TABLE `product_categories` (
  `p_cat_id` int(10) NOT NULL,
  `p_cat_title` text COLLATE utf8_unicode_ci NOT NULL,
  `p_cat_top` text COLLATE utf8_unicode_ci NOT NULL,
  `p_cat_image` text COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `product_categories`
--

INSERT INTO `product_categories` (`p_cat_id`, `p_cat_title`, `p_cat_top`, `p_cat_image`) VALUES
(1, 'Sneaker', 'yes', 'sneaker.jpg'),
(2, 'Dép', 'yes', 'dep.jpg'),
(3, 'Áo thun', 'yes', 'aothun.jpg'),
(4, 'Balo / Backpack', 'yes', 'balo.jpg'),
(5, 'Nón', 'yes', 'non.jpg'),
(6, 'Túi đeo chéo\r\n', 'yes', 'tuideocheo.jpg'),
(7, 'Phụ kiện', 'yes', 'phukien.jpg');

-- --------------------------------------------------------

--
-- Table structure for table `slider`
--

CREATE TABLE `slider` (
  `slider_id` int(10) NOT NULL,
  `slider_name` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `slider_image` text COLLATE utf8_unicode_ci NOT NULL,
  `slide_url` varchar(255) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `slider`
--

INSERT INTO `slider` (`slider_id`, `slider_name`, `slider_image`, `slide_url`) VALUES
(1, 'slide 1', 'hinh1_slide.jpg', 'http://localhost/myweb/cuahang.php'),
(2, 'slide 2', 'hinh2_slide.jpg', 'http://localhost/myweb/cuahang.php'),
(3, 'slide 3', 'hinh3_slide.jpg', 'http://localhost/myweb/cuahang.php'),
(4, 'slide 4', 'hinh4_slide.jpg', 'http://localhost/myweb/cuahang.php'),
(5, 'slide 5', 'hinh5_slide.jpg', 'http://localhost/myweb/cuahang.php'),
(6, 'slide 6', 'hinh6_slide.jpg', 'http://localhost/myweb/cuahang.php');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admins`
--
ALTER TABLE `admins`
  ADD PRIMARY KEY (`admin_id`);

--
-- Indexes for table `boxes_section`
--
ALTER TABLE `boxes_section`
  ADD PRIMARY KEY (`box_id`);

--
-- Indexes for table `cart`
--
ALTER TABLE `cart`
  ADD PRIMARY KEY (`p_id`);

--
-- Indexes for table `categories`
--
ALTER TABLE `categories`
  ADD PRIMARY KEY (`cat_id`);

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`customer_id`);

--
-- Indexes for table `customer_orders`
--
ALTER TABLE `customer_orders`
  ADD PRIMARY KEY (`order_id`);

--
-- Indexes for table `manufacturers`
--
ALTER TABLE `manufacturers`
  ADD PRIMARY KEY (`manufacturer_id`);

--
-- Indexes for table `payments`
--
ALTER TABLE `payments`
  ADD PRIMARY KEY (`payment_id`);

--
-- Indexes for table `pending_orders`
--
ALTER TABLE `pending_orders`
  ADD PRIMARY KEY (`order_id`);

--
-- Indexes for table `products`
--
ALTER TABLE `products`
  ADD PRIMARY KEY (`product_id`),
  ADD KEY `fk01_pc_p` (`p_cat_id`),
  ADD KEY `fk02_c_p` (`cat_id`);

--
-- Indexes for table `product_categories`
--
ALTER TABLE `product_categories`
  ADD PRIMARY KEY (`p_cat_id`);

--
-- Indexes for table `slider`
--
ALTER TABLE `slider`
  ADD PRIMARY KEY (`slider_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admins`
--
ALTER TABLE `admins`
  MODIFY `admin_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `boxes_section`
--
ALTER TABLE `boxes_section`
  MODIFY `box_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `categories`
--
ALTER TABLE `categories`
  MODIFY `cat_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `customer_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `customer_orders`
--
ALTER TABLE `customer_orders`
  MODIFY `order_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `manufacturers`
--
ALTER TABLE `manufacturers`
  MODIFY `manufacturer_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `payments`
--
ALTER TABLE `payments`
  MODIFY `payment_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `pending_orders`
--
ALTER TABLE `pending_orders`
  MODIFY `order_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `products`
--
ALTER TABLE `products`
  MODIFY `product_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;

--
-- AUTO_INCREMENT for table `product_categories`
--
ALTER TABLE `product_categories`
  MODIFY `p_cat_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=16;

--
-- AUTO_INCREMENT for table `slider`
--
ALTER TABLE `slider`
  MODIFY `slider_id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `products`
--
ALTER TABLE `products`
  ADD CONSTRAINT `fk01_pc_p` FOREIGN KEY (`p_cat_id`) REFERENCES `product_categories` (`p_cat_id`),
  ADD CONSTRAINT `fk02_c_p` FOREIGN KEY (`cat_id`) REFERENCES `categories` (`cat_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
