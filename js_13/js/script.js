var config = {
    type: Phaser.AUTO,
    width: 832,
    height: 832,
    scene: {
        preload: preload,
        create: create,
        update: update
    }
};

var game = new Phaser.Game(config);

function preload ()
{
    this.load.image('bg-l', 'assets/bg-light.png');
    this.load.image('bg-d', 'assets/bg-dark.png');
   // this.load.spritesheet('rick', 'assets/Rick .png',360,360);
}

function create ()
{
    this.add.image(416, 416, 'bg-l');

    //rick = this.add.sprite(720,720,'rick');



}

function update ()
{
}
