var c = document.getElementById('canvasConstellation');
var $ = c.getContext('2d');
var w = c.width = window.innerWidth * 0.4;
var h = c.height = (window.innerHeight * 0.5) + window.innerHeight;
var nodes;
var num = 75; // number of nodes
var minDist = 90; // min. distance between nodes in order to connect

createPoints();
run();

function createPoints() {
  nodes = [];
  for (var i = 0; i < num; i++) {
    var node = {
      rad: 1,
      x: Math.random() * w,
      y: Math.random() * h,
      vx: Math.random() * 0.2,
      vy: Math.random() * 0.2,
      update: function () {
        this.x += this.vx;
        this.y += this.vy;
        if (this.x > w) {
          this.x = 0;
        } else if (this.x < 0) {
          this.x = w;
        }
        if (this.y > h) {
          this.y = 0;
        } else if (this.y < 0) {
          this.y = h;
        }
      },
      draw: function () {
        $.fillStyle = "cornflowerblue";
        $.beginPath();
        $.arc(this.x, this.y, this.rad, 0, Math.PI * 2, true);
        $.fill();
        $.closePath();
      }
    };
    nodes.push(node);
  }
}

function run() {
  $.fillStyle = 'hsla(242, 40%, 5%, 1)';
  $.fillRect(0, 0, w, h);

  for (i = 0; i < num; i++) {
    var n1 = nodes[i];
    nodes[i].update();
    nodes[i].draw(); //draw the points

    for (var j = i + 1; j < num; j++) {
      var n2 = nodes[j];

      connect(n1, n2); // check if i and j can connect etc.
    }
  }
  window.requestAnimationFrame(run);
}

function connect(na, nb) {
  var dx = nb.x - na.x;
  var dy = nb.y - na.y;
  var dist = Math.sqrt(dx * dx + dy * dy); // distance = √ x^2 + y^2
  if (dist < minDist) {
    $.lineWidth = 1;
    $.beginPath();
    $.strokeStyle = "hsla(" + parseInt(Math.random() * 360, 10) + ", 85%, 55%, 0.25)";
    $.moveTo(na.x, na.y);
    $.lineTo(nb.x, nb.y);
    $.stroke();
    $.closePath();
  }
}

window.addEventListener('resize', function () {
  var w = c.width = window.innerWidth * 0.4;
  var h = c.height = (window.innerHeight * 0.5) + window.innerHeight;
  // c.width = w = window.innerWidth;
  // c.height = h = window.innerHeight;
});