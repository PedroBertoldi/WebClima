$(document).ready(function () {
    $("#cidade").change(function () {
        const cidade = this.value;
        $.ajax({
            url: 'home/BuscarPrevisoes',
            type: 'GET',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: { cidade: cidade },
            success: function (data) {
                let linha = $("#linha-previsao");
                linha.text("Previsão to tempo para os proximos dias em " + cidade);
                linha.removeClass('invisivel');
                let body = $("#body-previsao");
                body.empty();
                data.forEach(d => {
                    body.append(`
                    <div class="col-2">
                        <div class="card mt-2">
                            <div class="card-header text-white bg-primary">
                                ${new Date(d.DataPrevisao).toLocaleString(undefined, { weekday: 'long' })}
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <span>${d.Clima}</span>
                                    <span>Minima ${d.TemperaturaMinima} Cº</span>
                                    <span>Maxima ${d.TemperaturaMaxima} Cº</span>
                                </div>
                            </div>
                        </div>
                    </div>`);
                });
                body.removeClass('invisivel');
            },
            error: function (err) {
                console.log(err);
            }
        });
    });
});
