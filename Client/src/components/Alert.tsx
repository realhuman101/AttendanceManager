interface Props {
	children: string,
	type: "primary" | "secondary" | "success" | "danger",
}

const Alert = ({children, type = "primary"}: Props) => {
	return (
		<div className={"alert alert-dismissable alert-"+type}>{children}</div>
	)
}

export default Alert