function createAssemblyLine() {
    const decoratorFunctions = {
        hasClima(obj) {
            obj.temp = 21;
            obj.tempSettings = 21;
            obj.adjustTemp = () => {
                if (obj.temp < obj.tempSettings) {
                    obj.temp++;
                } else if (obj.temp > obj.tempSettings) {
                    obj.temp--;
                }
            }
        },
        hasAudio(obj) {
            obj.currentTrack = {};
            obj.nowPlaying = () => {
                if (obj.currentTrack) {
                    console.log(`Now playing '${obj.currentTrack.name}' by ${obj.currentTrack.artist}`);
                }     
            }
        },
        hasParktronic(obj){
            obj.checkDistance = function(distance) {
                let result = ' ';
                if (distance < 0.1) {
                    result = 'Beep! Beep! Beep!';
                } else if (distance >= 0.1 && distance < 0.25) {
                    result = 'Beep! Beep!';
                } else if (distance >= 0.25 && distance < 0.5) {
                    result = 'Beep!';
                } else {
                   result = ' ';
                }

                console.log(result);
            }
        }
    };

    return decoratorFunctions;
}



const assemblyLine = createAssemblyLine();

const myCar = {
    make: 'Toyota',
    model: 'Avensis'
};

assemblyLine.hasClima(myCar);
console.log(myCar.temp);
myCar.tempSettings = 18;
myCar.adjustTemp();
console.log(myCar.temp);

assemblyLine.hasAudio(myCar);
myCar.currentTrack = {
    name: 'Never Gonna Give You Up',
    artist: 'Rick Astley'
};
myCar.nowPlaying();