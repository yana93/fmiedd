// Star Class Constructor
function Star(x, y, size, velocity) {
    this.x = x;// Position X in canvas
    this.y = y;// Position Y in canvas
    this.size = size;// Size of the star
    this.velocity = velocity;// Speed of the star
}

// Starfield Class Constructor
function Starfield() {
    this.fps = 30;
    this.canvas = null;
    this.width = 0;
    this.height = 0;
    this.minVelocity = 15;
    this.maxVelocity = 30;
    this.stars = 100;
    this.intervalId = 0;
}


// Main function
// Initialises the startfield and where it will be
Starfield.prototype.initialise = function(div) {
    var self = this;// Variable witch is the Starfield

    // Store div
    this.containerDiv = div;// We store it in property out side the constructor
    // Store the dimentions of the browser
    self.width = window.innerWidth;
    self.height = window.innerHeight;

    // This event is for resize on window
    // We add Event Listener to not interfere with other events
    window.onresize = function(event) {
        self.width = window.innerWidth;
        self.height = window.innerHeight;
        // The canvas too must be resized
        self.canvas.width = self.width;
        self.canvas.height = self.height;
        self.draw();// Draw the new size
    };

    // Create canvas in the html document
    var canvas = document.createElement("canvas");// Create
    div.appendChild(canvas);// Add to DOM
    this.canvas = canvas;
    this.canvas.width = this.width;
    this.canvas.height = this.height;
};

Starfield.prototype.start = function() {

    // We create ower Stars hire
    var stars = [];// Array
    for (var i = 0; i < this.stars; i++) {
        stars[i] = new Star(// New object of Star
                Math.random() * this.width,// Random X position
                Math.random() * this.height,// Random Y position
                Math.random() * 3 + 1,// Random Size
                (Math.random() * (this.maxVelocity - this.minVelocity)) + this.minVelocity// Random speed
            );
    }
    this.stars = stars;// Now we store it in the property of the Starfield

    // Set interval in witch we will refresh the Starfield
    var self = this;// Variable witch is the Starfield
    this.intervalId = setInterval(function() {// If we whant to stop it
        self.update();// Update the new changes
        self.draw();// Draw the updates
        /*
            Time in witch to update.
            1000ms = 1 sec
            1000ms / 30 <=> 30 Frames Per Second in one Second
        */
    }, 1000 / self.fps);
};

Starfield.prototype.stop = function() {
    clearInterval(this.intervalId);// Remove the IntervalId to stop updating
};

// Update with new changes in the Starfield
Starfield.prototype.update = function() {
    var dt = 1 / this.fps;// To increase speed

    for(var i = 0; i < this.stars.length; i++) {// For every star in stars
        var star = this.stars[i];
        star.y += dt * star.velocity;// We increase the speed

        //  If the star has moved from the bottom of the screen, spawn it at the top.
        if (star.y > this.height) {
            this.stars[i] = new Star(// New object for stars[i] array
                    Math.random() * this.width,// Random X
                    0,// Y = 0 to start on top of screen
                    Math.random() * 3 + 1,// Random size
                    (Math.random() * (this.maxVelocity - this.minVelocity)) + this.minVelocity// Rendom speed
                );
        }
    }
};

// Draw the objects
Starfield.prototype.draw = function() {

    //  Get the drawing context.
    var ctx = this.canvas.getContext("2d");

    //  Draw the background.
    ctx.fillStyle = '#000000';
    ctx.fillRect(0, 0, this.width, this.height);

    //  Draw stars.
    ctx.fillStyle = '#ffffff';
    for(var i=0; i<this.stars.length;i++) {
        var star = this.stars[i];
        ctx.fillRect(star.x, star.y, star.size, star.size);
    }
};
