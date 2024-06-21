export const formatNumber = (num) => {
    return num.toLocaleString();
}

export const dateEngformat = (dateinput) => {
    // Split the input date string into an array of [year, month, day]
    const [year, month, day] = dateinput.split('/');

    // Create an array of month names
    const monthNames = ["Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"];

    // Get the month name from the array (subtract 1 because months are zero-indexed)
    const monthName = monthNames[parseInt(month) - 1];

    // Return the formatted date string
    return `${monthName} ${parseInt(day)}, ${year}`;
};
