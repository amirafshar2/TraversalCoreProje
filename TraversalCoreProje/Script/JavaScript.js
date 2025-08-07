$(document).ready(function () {
    // کدهای jQuery شما
    <script>

        $('#commentbtn').click(function () {
            // ایجاد شیء جدید برای ارسال به سرور
            var mComment = {
            CommentUser: $('#name').val(),
        CommentContent: $('#comment').val(),
        Destiniton: $('#idd').val()
            };

        $.ajax({
            url: '/Comment/AddComment',
        type: 'POST',
        contentType: 'application/json',
        data: JSON.stringify(mComment),
        success: function (response) {
                    if (response.success) {
                        var addedComment = response.comment;
        var commentHtml = createCommentHtml(addedComment.name, addedComment.content, "Just now");
        $('#comments-list').append(commentHtml);
        $('#comment').val('');
        $('#name').val('');
                    }
                },
        error: function (errorThrown) {
            console.log(errorThrown);
                }
            });
        });
        // تابع ساخت HTML کامنت جدید
        function createCommentHtml(commentUser, commentContent, commentDate) {
            return `
        <div class="media mt-4">
            <div class="img-circle">
                <img src="/Traversal-Liberty/assets/images/c1.jpg" class="img-fluid" alt="...">
            </div>
            <div class="media-body">
                <ul class="time-rply mb-2">
                    <li>
                        <a href="#URL" class="name mt-0 mb-2 d-block">${commentUser}</a>
                        ${commentDate}
                    </li>
                    <li class="reply-last">
                        <a href="#reply" class="reply">
                            Reply
                        </a>
                    </li>
                </ul>
                <p>
                    ${commentContent}
                </p>
            </div>
        </div>
                                                                                            `;
        }
    </script>
});