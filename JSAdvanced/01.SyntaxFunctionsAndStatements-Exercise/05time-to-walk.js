function timeToWalk(steps, footprint, speed) {
    let distance = footprint * steps;
    let time = Math.round(distance / speed * 3.6);
    time += Math.floor(distance / 500) * 60;

    let hours = Math.floor(time / 3600).toFixed(0).padStart(2, '0');
    let minutes = Math.floor(time / 60).toFixed(0).padStart(2, '0');
    let seconds = (time % 60).toFixed(0).padStart(2, '0');

    console.log(`${hours}:${minutes}:${seconds}`);
}

