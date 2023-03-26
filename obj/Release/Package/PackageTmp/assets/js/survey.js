var countDownDate = new Date().getTime() + 600000;

// Cập nhật thời gian đếm ngược sau mỗi 1 giây
var x = setInterval(function () {
	// Lấy thời gian hiện tại
	var now = new Date().getTime();

	// Tính khoảng cách giữa thời gian hiện tại và thời gian bắt đầu đếm ngược
	var distance = countDownDate - now;

	// Tính toán thời gian còn lại trong định dạng phút và giây
	var minutes = Math.floor((distance % (1000 * 60 * 60)) / (1000 * 60));
	var seconds = Math.floor((distance % (1000 * 60)) / 1000);

	// Hiển thị thời gian còn lại trong một thẻ p
	document.getElementById("countdown").innerHTML = minutes + " Min " + seconds + " Sec ";

	// Nếu thời gian đếm ngược kết thúc, hiển thị thông báo
	if (distance < 0) {
		clearInterval(x);
		document.getElementById("countdown").innerHTML = "End!";
	}
}, 1000);