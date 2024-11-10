const CurrentDatePage = ({ backTo }) => {
    const date = new Date();
    const showTime = date.getHours()
        + ':' + date.getMinutes()
        + ':' + date.getSeconds();
    const timeZone = Intl.DateTimeFormat().resolvedOptions().timeZone;

    return (
        <div>
            <h1>Current Time:</h1>
            <h2>{showTime}</h2>

            <h1>Timezone:</h1>
            <h2>{timeZone}</h2>
        </div>
    )
}

export default CurrentDatePage;