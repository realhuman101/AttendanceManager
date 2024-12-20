import { useState } from "react";
import jsQR from "jsqr";

function Scan() {
  
  //@ts-expect-error stfu
  const handleFileUpload = async (event) => {
    const file = event.target.files[0];
    if (file) {
      const reader = new FileReader();
      reader.onload = (e) => {
        const img = new Image();
        //@ts-expect-error stfu
        img.src = e.target.result as string;
        img.onload = () => {
          const canvas = document.createElement("canvas");
          canvas.width = img.width;
          canvas.height = img.height;
          const ctx = canvas.getContext("2d");
          //@ts-expect-error stfu
          ctx.drawImage(img, 0, 0, img.width, img.height);
          //@ts-expect-error stfu
          const imageData = ctx.getImageData(0, 0, canvas.width, canvas.height);
          const code = jsQR(imageData.data, imageData.width, imageData.height);
          if (code) {


            setView(<>
              <p>hi</p>
            </>);
          }
        };
      };
      reader.readAsDataURL(file);
    }
  };

  const [view, setView] = useState(<>
      <h1>Scan A QR Code</h1>
      <input type="file" accept="image/*" onChange={handleFileUpload} />
    </>);

  return (
    <div className="page" style={{ width: "100%", height: "100dvh" }}>
      {view}
    </div>
  );
}

export default Scan;
