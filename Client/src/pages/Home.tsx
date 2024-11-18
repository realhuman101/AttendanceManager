function Home() {
  return (
	<div className="page">
		<div>
			<h1>Welcome!</h1>
			<button onClick={() => {window.location.href='/scan'}}>Scan QR Code</button>
		</div>
	</div>
  )
}

export default Home