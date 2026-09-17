(function () {
"use strict";

var buttonColors=["red", "blue", "green", "yellow"];
var gamePattern=[];
var userClickedPattern=[];
var started=false;
var gameWon = false;
var level=0;
var isPlayingSequence = false;
const WIN_LEVEL = 3; // ajustar al nivel deseado

$(document).on("keypress",function(event){
    if(!started){
        $("#level-title").text("Level "+level);
        nextSequence();
        started=true;
    }
});
$(".btn").on("click",function(){
    if(gameWon || isPlayingSequence) return;
    var userChosenColour=$(this).attr("id");
    userClickedPattern.push(userChosenColour);
    playSound(userChosenColour);
    animatePress(userChosenColour);
    checkAnswer(userClickedPattern.length-1);
});
function nextSequence(){
    userClickedPattern = [];
    level++;
    $("#level-title").html('<span style="font-family: \'GreekFreak\', cursive;">Nivel ' + level + '</span>');
    isPlayingSequence = true;
    // Mostrar victoria al alcanzar WIN_LEVEL
    if(level === WIN_LEVEL){
        showWin();
        isPlayingSequence = false;
        return;
    }
    var randomNumber = Math.floor(Math.random() * 4);
    var randomChosenColour = buttonColors[randomNumber];
    gamePattern.push(randomChosenColour);

    // Reproducir toda la secuencia guardada en orden
    for (let i = 0; i < gamePattern.length; i++) {
        let col = gamePattern[i];
        setTimeout(function() {
            $("#" + col).fadeIn(100).fadeOut(100).fadeIn(100);
            playSound(col);
        }, i * 600); // 600ms entre cada color (ajustable)
    }
    // Liberar entradas del usuario tras terminar la reproducción
    setTimeout(function() {
        isPlayingSequence = false;
    }, gamePattern.length * 600 + 100);
}
function playSound(name){
    var audio=new Audio("sounds/"+name+".mp3");
    audio.play();
}
function animatePress(currentColor){
  $("#"+currentColor).addClass("pressed");
  setTimeout(function() {
    $("#" + currentColor).removeClass("pressed");
  }, 100);
}

function checkAnswer(currentLevel){
    if(gamePattern[currentLevel]==userClickedPattern[currentLevel]){
        console.log("success");
        if(gamePattern.length==userClickedPattern.length){
            setTimeout(function() {
                nextSequence();
            }, 1000);
        }
    }
    else{
        console.log("wrong");
        playSound("wrong");
        $("body").addClass("game-over");
        setTimeout(function(){
            $("body").removeClass("game-over");
        },200);
        $("#level-title").html('<span style="font-family: \'GreekFreak\', cursive;">Perdiste, presiona cualquier tecla para reiniciar</span>');
        startOver();
    }
    
}
function startOver(){
    level=0;
    gamePattern=[];
    started=false;
    gameWon = false;
    isPlayingSequence = false;
}

function showWin(){
    gameWon = true;
    // Detener listeners
    $(document).off('keypress');
    $('.btn').off('click');

    // Actualizar título
    $("#level-title").html('<span style="font-family: \'GreekFreak\', cursive;">¡Ganaste!</span>');

    // Crear overlay y botón para ir a sala 3
    var overlay = $('<div id="win-overlay" class="win-overlay">'
        + '<div class="win-box">'
        + '<h2>¡Felicidades!</h2>'
        + '<p>Resististe el canto de las sirenas.</p>'
        + '<button id="next-room" class="next-room">Siguiente desafio</button>'
        + '</div>'
        + '</div>');

    $('body').append(overlay);

    $('#next-room').on('click', function(){
        // Navegar a la acción que lleva a la sala 3
        window.location.href = '/Home/irASala3';
    });
}

})();