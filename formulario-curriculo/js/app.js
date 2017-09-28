const makePost = (event) => {
  event.preventDefault();
  let file = $("#Curriculum")[0].files;
  let candidate = {
    "Name": $("#Name").val(),
    "Email": $("#Email").val(),
    "Country": $("#Country").val(),
    "Estate": $("#State").val(),
    "City": $("#City").val()
  };

  console.log(candidate);
  console.log(file);

  let formData = new FormData();
  formData.append("Candidates", JSON.stringify(candidate));
  formData.append("file", file[0]);

  $.ajax({
    url: "http://localhost:54392/api/candidate",
    data: formData,
    type: "POST",
    crossDomain: true,
    processData: false,
    contentType: false,
    dataType: 'json',
    success: function(data, textStatus, jqXHR) {
      console.log("Send");
    },
    error: function(jqXHR, textStatus, errorThrown) {
      console.log("Error");
    }
  });
}

$("#Submit").on("click", makePost);
