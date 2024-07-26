export const formatNumber = (num) => {
  return num.toLocaleString();
};

export const dateEngformat = (dateinput) => {
  // Create a new Date object from the input date string
  const date = new Date(dateinput);

  // Create an array of month names
  const monthNames = [
    "Jan", "Feb", "Mar", "Apr", "May", "Jun",
    "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
  ];

  // Extract the day, month, and year from the Date object
  const year = date.getFullYear();
  const monthName = monthNames[date.getMonth()];
  const day = date.getDate();

  // Return the formatted date string
  return `${monthName} ${day}, ${year}`;
};

export const formatTime = (timeString) => {
  const [hours, minutes, seconds] = timeString.split(":").map(Number);

  let formattedTime = "";
  if (hours > 0) {
    formattedTime += `${hours} hours `;
  }
  if (minutes > 0 || hours > 0) {
    formattedTime += `${minutes} minutes`;
  }

  return formattedTime.trim();
};

export const CoverMinutesToHours = (minutes) => {
  const hours = Math.floor(minutes / 60);
  const remainingMinutes = minutes % 60;
  return `${hours} hours ${remainingMinutes} minutes`;
}

export const nameNavigation = (courseName) => {
  return courseName.toLowerCase().split(' ').join('-');
};

export const formatTimeToHours = (timeString) =>{
  const [hours, minutes, seconds] = timeString.split(':').map(Number);

  const totalHours = hours + (minutes / 60) + (seconds / 3600);

  const formattedHours = totalHours.toFixed(1);

  return `${formattedHours} Hrs`;
}
