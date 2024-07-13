import { CSSProperties } from "react"

interface Props {
	children: string,
	type: "primary" | "secondary" | "success" | "danger",
	styling : CSSProperties
}

const Alert = ({children, type = "primary", styling}: Props) => {
	return (
		<div style={styling} className={"alert alert-dismissable alert-"+type}>{children}</div>
	)
}

export default Alert