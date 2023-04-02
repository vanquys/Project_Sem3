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

	// thông báo còn 5 phút

	if (distance < 300000 && distance > 299000) {
		alert("5 min remain!");
	}

	// thông báo còn 2 phút

	if (distance < 120000 && distance > 119000) {
		alert("2 min remain!");
	}

	// Tư động submit sau khi hết giờ
	if (distance < 0) {
		$("#survey-form").submit();
	}
}, 1000););