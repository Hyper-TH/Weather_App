export const Weather = (props) => {
    return (
        <div>
            {props.date}
            {props.summary}
            {props.temperature}
        </div>
    )
}