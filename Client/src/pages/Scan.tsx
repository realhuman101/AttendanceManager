import { useState } from "react";
import QrScanner from "react-qr-scanner";

function Scan() {
  const [data, setData] = useState("No result");

  const handleScan = (result: string | null) => {
    if (result) {
      setData(result);
    }
  };

  const handleError = (error: any) => {
    console.error("Error scanning QR code:", error);
  };

  const handleFileSelect = () => {
    document.getElementById("legacyUploader")?.click();
  };

  return (
    <div className="page" style={{ width: "100%", height: "100vh" }}>
      <h1>Scan</h1>
      <QrScanner
        delay={300}
        onError={handleError}
        onScan={handleScan}
        style={{ width: "100%", height: "100%" }}
        legacyMode={true} 
      />
      <button
        onClick={handleFileSelect}
        style={{
          marginTop: "20px",
          padding: "10px 20px",
          fontSize: "16px",
          cursor: "pointer",
        }}
      >
        Upload QR Code
      </button>
      <input
        id="legacyUploader"
        type="file"
        accept="image/*"
        style={{ display: "none" }}
        onChange={(e) => {
          const file = e.target.files?.[0];
          if (file) {
            const reader = new FileReader();
            reader.onload = (event) => {
              const image = event.target?.result;
              if (image) {
                (document.querySelector("canvas") as HTMLCanvasElement).style.backgroundImage = `url(${image})`;
              }
            };
            reader.readAsDataURL(file);
          }
        }}
      />
      <p>Scanned Data: {data}</p>
    </div>
  );
}

export default Scan;
