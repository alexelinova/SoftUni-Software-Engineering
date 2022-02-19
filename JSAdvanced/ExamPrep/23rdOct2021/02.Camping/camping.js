class SummerCamp {
    constructor(organizer, location) {

        this.organizer = organizer;
        this.location = location;

        this.priceForTheCamp = {
            child: 150,
            student: 300,
            collegian: 500
        }

        this.listOfParticipants = [];
    }

    registerParticipant(name, condition, money) {
        if (!this.priceForTheCamp[condition]) {
            throw new Error('Unsuccessful registration at the camp.');
        }

        let participant = this.listOfParticipants.find(x => x.name == name);

        if (participant) {
            return `The ${name} is already registered at the camp.`;
        }

        if (money < this.priceForTheCamp[condition]) {
            return `The money is not enough to pay the stay at the camp.`;
        }

        participant = {
            name,
            condition,
            power: 100,
            wins: 0
        }

        this.listOfParticipants.push(participant);

        return `The ${name} was successfully registered.`
    }

    unregisterParticipant(name) {
        let indexOfParticipant = this.listOfParticipants.findIndex(x => x.name == name);

        if (indexOfParticipant == -1) {
            throw new Error(`The ${name} is not registered in the camp.`)
        }

        this.listOfParticipants.splice(indexOfParticipant, 1);

        return `The ${name} removed successfully.`
    }

    timeToPlay(typeOfGame, participant1, participant2) {

        let participantOne = this.listOfParticipants.find(x => x.name == participant1);

        if (!participantOne) {
            throw new Error('Invalid entered name/s.');
        }

        if (typeOfGame == 'Battleship') {
            participantOne.power += 20;

            return `The ${participant1} successfully completed the game ${typeOfGame}.`
        } else if (typeOfGame == 'WaterBalloonFights') {

            let participantTwo = this.listOfParticipants.find(x => x.name == participant2);

            if (!participantTwo) {
                throw new Error('Invalid entered name/s.');
            }

            if (participantOne.condition != participantTwo.condition) {
                throw new Error('Choose players with equal condition.');
            }

            if (participantOne.power > participantTwo.power) {
                participantOne.wins++;
                return `The ${participantOne.name} is winner in the game ${typeOfGame}.`

            } else if (participantTwo.power > participantOne.power) {
                participantTwo.wins++;
                return `The ${participantTwo.name} is winner in the game ${typeOfGame}.`

            } else {
                return `There is no winner.`

            }
        }
    }

    toString() {
     let output = [];
     output.push(`${this.organizer} will take ${this.listOfParticipants.length} participants on camping to ${this.location}`);

     this.listOfParticipants
     .sort((a, b) => b.wins - a.wins)
     .forEach(x => {
         output.push(`${x.name} - ${x.condition} - ${x.power} - ${x.wins}`);
     });

     return output.join('\n');
    }
}



const summerCamp = new SummerCamp("Jane Austen", "Pancharevo Sofia 1137, Bulgaria");
console.log(summerCamp.registerParticipant("Petar Petarson", "student", 300));
console.log(summerCamp.timeToPlay("Battleship", "Petar Petarson"));
console.log(summerCamp.registerParticipant("Sara Dickinson", "child", 200));
console.log(summerCamp.registerParticipant("Dimitur Kostov", "student", 300));
console.log(summerCamp.timeToPlay("WaterBalloonFights", "Petar Petarson", "Dimitur Kostov"));

console.log(summerCamp.toString());
