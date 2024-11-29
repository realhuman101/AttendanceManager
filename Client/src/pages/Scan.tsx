import { useRef, useState } from "react";
//@ts-expect-error idgaf
import QrReader from "react-qr-scanner";

function Scan() {
  const [data, setData] = useState("No result");
  const qrReader = useRef(null);

  //@ts-expect-error idgaf
  const handleScan = (result) => {
    try {
      if (result) {
        console.log(result);
        setData(result);
      }
    } catch {
      console.log('stfu2')
    }
  };

  //@ts-expect-error idgaf
  const handleError = (error) => {
    console.log("Error scanning QR code:", error);
  };

  // const handleFileSelect = () => {
  //   document.getElementById("legacyUploader")?.click();
  // };
  const openImageDialog = () => {
    try {
      //@ts-expect-error stfu
      qrReader.current.openImageDialog()
    } catch {
      console.log('stfu')
    }
  }
  return (
    <div className="page" style={{ width: "100%", height: "100dvh" }}>
      <h1>Scan</h1>  

      <QrReader
        ref={qrReader}
        delay={100}
        onScan={handleScan}
        onError={handleError}
        resolution={800}
        legacyMode
      />
      <input type="button" value="Submit QR Code" onClick={openImageDialog} />
      <p>Scanned Data: {data}</p>
    </div>
  );
}

export default Scan;
